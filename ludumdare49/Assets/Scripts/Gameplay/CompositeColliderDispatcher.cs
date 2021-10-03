using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeColliderDispatcher : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        var minDistance = float.MaxValue;
        var foundTransform = (Transform)null;

        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            var distance = Vector2.Distance(collision.contacts[0].point, new Vector2(child.transform.position.x, child.transform.position.y));
            if (distance < minDistance)
            {
                minDistance = distance;
                foundTransform = child;
            }
        }

        var childCollider = foundTransform?.GetComponent<IChildCollider>();
        if (childCollider != null)
            childCollider.CollisionEnter(collision);
    }
}

public interface IChildCollider
{
    void CollisionEnter(Collision2D collision);
}