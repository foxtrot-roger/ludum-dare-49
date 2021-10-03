using System.Collections;
using UnityEngine;

public class ExplodeOnContact : MonoBehaviour, IInteractable
{
    public float ExplosionDistance;
    public float ExplosionForce;

    public GameObject ExplosionPrefab;
    public AudioClip ExplosionSound;

    bool exploded;

    ShakeCamera shakeCamera;
    void Start()
    {
        shakeCamera = FindObjectOfType<ShakeCamera>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        ActivateEffect();
    }

    public void ActivateEffect()
    {
        if (exploded)
            return;

        exploded = true;

        Extensions.ActivateEffect(transform.position, ExplosionDistance);
        MyPhysics.AddLinearExplosionForce(transform.position, ExplosionForce, ExplosionDistance);
        MyParticles.PlayEffect(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
        GameAudio.PlayEffect(ExplosionSound);

        shakeCamera.Shake();

        Destroy(gameObject);
    }
}
