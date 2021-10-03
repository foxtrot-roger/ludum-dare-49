using UnityEngine;

public static class MyPhysics
{
    public static void AddLinearExplosionForce(Vector2 position, float force, float maxDistance)
    {
        foreach (var item in Object.FindObjectsOfType<Rigidbody2D>())
        {
            //item.AddForce((item.position - position).normalized * force / Time.deltaTime);
            if (item.bodyType == RigidbodyType2D.Dynamic)
                if (Vector2.Distance(item.transform.position, position) < maxDistance)
                    item.velocity += (item.position - position).normalized * force;
        }
    }
}