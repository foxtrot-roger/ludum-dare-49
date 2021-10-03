using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    Rigidbody2D rb;

    public InputConfiguration Input;

    public AudioClip JumpClip;

    public float MinSpeed;
    public float MaxSpeed;
    public float AirDrag;
    public float AirFriction;

    public float JumpHeight;

    bool isGrounded;
    bool isWallBoundLeft;
    bool isWallBoundRight;
    Vector2 collisionNormal;
    float collisionFriction;
    public Dictionary<GameObject, Vector2[]> collisions = new Dictionary<GameObject, Vector2[]>();

    public bool ShowCollisions;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    float horizontal;
    bool jump;

    private void Update()
    {
        horizontal = Input.ReadHorizontal();
        jump = Input.ReadJump();

        var velocity = rb.velocity;

        // no input but still moving on the ground (inertia)
        if (horizontal == 0 && isGrounded && velocity.x != 0)
            if (velocity.x < 0)
                horizontal = 0.5f;
            else if (velocity.x > 0)
                horizontal = -0.5f;

        if (!isGrounded)
        {
            if (isWallBoundLeft && horizontal < 0)
            {
                horizontal = 0;
            }
            else if (isWallBoundRight && horizontal > 0)
            {
                horizontal = 0;
            }
        }

        if (horizontal != 0)
        {
            velocity.x = Mathf.Clamp(velocity.x + horizontal * collisionFriction, -MaxSpeed, MaxSpeed);
        }
        rb.velocity = velocity;

        if (collisions.Count > 0 && jump)
        {
            if (isGrounded)
            {
                GameAudio.PlayEffect(JumpClip);

                velocity.y = Mathf.Sqrt(-2.0f * Physics2D.gravity.y * JumpHeight);
                rb.velocity = velocity;
            }
            else if (isWallBoundLeft && !isWallBoundRight)
            {
                GameAudio.PlayEffect(JumpClip);

                var direction = 1;
                velocity.y = Mathf.Sqrt(-2.0f * Physics2D.gravity.y * JumpHeight);
                velocity.x = MaxSpeed * direction;
                rb.velocity = velocity;

                isWallBoundLeft = false;
            }
            else if (!isWallBoundLeft && isWallBoundRight)
            {
                GameAudio.PlayEffect(JumpClip);

                var direction = -1;
                velocity.y = Mathf.Sqrt(-2.0f * Physics2D.gravity.y * JumpHeight);
                velocity.x = MaxSpeed * direction;
                rb.velocity = velocity;

                isWallBoundLeft = false;
            }
        }

        horizontal = 0;
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Platform")
            return;

        collisions.Add(collision.collider.gameObject, collision.contacts.Select(o => o.normal).ToArray());
        UpdateCollisionInfo();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Platform")
            return;

        collisions[collision.collider.gameObject] = collision.contacts.Select(o => o.normal).ToArray();
        UpdateCollisionInfo();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Platform")
            return;

        collisions.Remove(collision.collider.gameObject);
        UpdateCollisionInfo();
    }

    private void UpdateCollisionInfo()
    {
        if (collisions.Count == 0)
        {
            collisionNormal = Vector2.zero;
            collisionFriction = AirFriction;

            isGrounded = false;
            isWallBoundLeft = false;
            isWallBoundRight = false;
        }
        else
        {
            isGrounded = collisions.SelectMany(o => o.Value).Any(o => Vector2.Dot(Vector2.up, o) > 0.001f);
            isWallBoundLeft = collisions.SelectMany(o => o.Value).Any(o => Vector2.Dot(Vector2.right, o) > 0);
            isWallBoundRight = collisions.SelectMany(o => o.Value).Any(o => Vector2.Dot(Vector2.left, o) > 0);

            collisionNormal = collisions
                .SelectMany(o => o.Value)
                .Average();

            if (isGrounded)
            {
                var temp = collisions
                  .Select(o => o.Key.GetComponent<MyFriction>())
                  .Where(o => o != null)
                  .Select(o => o.PhysicsMaterial.friction)
                  .ToArray();
                if (temp.Length > 0)
                    collisionFriction = temp.Average();
                else
                    collisionFriction = AirFriction;
            }
            else
                collisionFriction = AirFriction;
        }
    }
}
