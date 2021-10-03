using UnityEngine;

public static class MyParticles
{
    public static void PlayEffect(GameObject explosionPrefab, Vector3 position, Quaternion identity, Transform parent)
    {
        var gfx = Object.Instantiate(explosionPrefab, position, identity, parent);
        Object.Destroy(gfx, gfx.GetComponent<ParticleSystem>().main.duration);
    }
}