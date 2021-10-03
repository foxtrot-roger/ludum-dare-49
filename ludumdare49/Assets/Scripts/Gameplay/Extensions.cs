using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions
{
    public static Vector2 Average(this IEnumerable<Vector2> vectors)
    {
        return vectors.Aggregate(Vector2.zero, (seed, current) => seed + current) / vectors.Count();
    }

    public static void Fit(this Camera camera, Vector2 levelSize, float levelSizeOnScreenInRatio = 1f)
    {
        var resolutionX = levelSize.x / Screen.width;
        var resolutionY = levelSize.y / Screen.height;

        if (resolutionX > resolutionY)
            camera.orthographicSize = resolutionX * Screen.height * levelSizeOnScreenInRatio / 2;
        else
            camera.orthographicSize = resolutionY * Screen.height * levelSizeOnScreenInRatio / 2;
    }

    public static void ActivateEffect(Vector2 position, float maxDistance)
    {
        foreach (var item in Object.FindObjectsOfType<MonoBehaviour>())
        {
            if (Vector2.Distance(item.transform.position, position) < maxDistance)
            {
                var interactable = item.GetComponent<IInteractable>();
                if (interactable != null)
                    interactable.ActivateEffect();
            }
        }
    }
}