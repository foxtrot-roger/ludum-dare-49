using System.Collections;
using TMPro;
using UnityEngine;

public class ExplodeAfterDelay : MonoBehaviour, IInteractable
{
    public float ExplosionDelay;
    public float ExplosionDistance;
    public float ExplosionForce;

    public GameObject ExplosionPrefab;
    public AudioClip ExplosionSound;


    public TextMeshPro Text;
    float remaining = -1;

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
        if (remaining != -1)
            return;

        remaining = ExplosionDelay;
        StartCoroutine(Explode());
        StartCoroutine(UpdateUI());
    }

    IEnumerator UpdateUI()
    {
        while (remaining > 0)
        {
            yield return new WaitForSeconds(0.1f);
            remaining -= 0.1f;
            Text.SetText(Mathf.RoundToInt(remaining).ToString());
        }
    }


    IEnumerator Explode()
    {
        yield return new WaitForSeconds(ExplosionDelay);

        Extensions.ActivateEffect(transform.position, ExplosionDistance);
        MyPhysics.AddLinearExplosionForce(transform.position, ExplosionForce, ExplosionDistance);
        MyParticles.PlayEffect(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
        GameAudio.PlayEffect(ExplosionSound);

        shakeCamera.Shake();

        Destroy(gameObject);
    }
}
