using System.Collections;
using TMPro;
using UnityEngine;

public class CrumbleOnContact : MonoBehaviour, IInteractable, IChildCollider
{
    public float ExplosionDelay;

    public GameObject ExplosionPrefab;
    public AudioClip ExplosionSound;

    public TextMeshPro Text;
    float remaining = -1;


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

        StartCoroutine(UpdateUI());
        StartCoroutine(Explode());
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

        MyParticles.PlayEffect(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
        GameAudio.PlayEffect(ExplosionSound);

        Destroy(gameObject);
    }

    public void CollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        ActivateEffect();
    }
}
