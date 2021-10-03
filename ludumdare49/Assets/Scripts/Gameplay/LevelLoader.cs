using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    static LevelLoader instance;

    public TileDefinition[] Builders;

    public TextAsset[] Levels;
    GameObject currentLevel;

    private void Start()
    {
        instance = this;
    }

    public void LoadLevel(int level)
    {
        if (currentLevel != null)
            Destroy(currentLevel);

        currentLevel = new GameObject();
        currentLevel.transform.parent = transform;

        var composites = new Dictionary<char, GameObject>();

        var levelDefinition = Levels[level];
        var lines = levelDefinition.text.Split('\n');
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                var key = lines[y][x];

                var tileDefinition = Builders.SingleOrDefault(o => o.Key == key);
                if (tileDefinition != null)
                {
                    var parent = currentLevel.transform;
                    if (tileDefinition.ParentPrefab != null)
                    {
                        if (!composites.ContainsKey(key))
                            composites.Add(key, Instantiate(tileDefinition.ParentPrefab, new Vector2(x, -y), Quaternion.identity, currentLevel.transform));

                        parent = composites[key].transform;
                    }

                    Instantiate(tileDefinition.Prefab, new Vector2(x, -y), Quaternion.identity, parent);
                }
            }
        }

        currentLevel.transform.position = new Vector3(-lines.Max(o => o.Length) / 2f + 1f, lines.Length / 2f);
    }
    public void UnloadLevel()
    {
        Destroy(currentLevel);
        currentLevel = null;
    }

    public static void StartLevel(int level)
        => instance.LoadLevel(level);

    public static void StopLevel()
        => instance.UnloadLevel();
}

[Serializable]
public class TileDefinition
{
    public char Key;
    public GameObject ParentPrefab;
    public GameObject Prefab;
}
