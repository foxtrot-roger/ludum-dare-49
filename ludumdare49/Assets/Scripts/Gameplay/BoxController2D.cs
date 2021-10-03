using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BoxController2D : MonoBehaviour
{
    Rigidbody2D rigidbody;

    public float MinSpeed;
    public float MaxSpeed;
    public float AirFriction;

    bool isGrounded;
    bool isWallBound;
    Vector2 collisionNormal;
    float collisionFriction;
    public Dictionary<GameObject, Vector2[]> collisions = new Dictionary<GameObject, Vector2[]>();

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var velocity = rigidbody.velocity;
        velocity.x = Mathf.Lerp(velocity.x, 0, collisionFriction);
        rigidbody.velocity = velocity;
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
            isWallBound = false;
        }
        else
        {
            collisionNormal = collisions.SelectMany(o => o.Value).Average();
            var temp = collisions
                .Select(o => o.Key.GetComponent<MyFriction>())
                .Where(o => o != null)
                .Select(o => o.PhysicsMaterial.friction)
                .ToArray();
            if (temp.Length > 0)
                collisionFriction = temp.Average();
            else
                collisionFriction = AirFriction;

            isGrounded = Vector2.Dot(Vector2.up, collisionNormal) > 0;
            isWallBound = Vector2.Dot(Vector2.left, collisionNormal) > 0 || Vector2.Dot(Vector2.right, collisionNormal) > 0;
        }
    }
}
