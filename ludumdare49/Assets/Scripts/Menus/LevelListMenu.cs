using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelListMenu : MonoBehaviour
{
    LevelLoader levelLoader;

    public RectTransform LevelGrid;
    public GameObject LevelButtonPrefab;

    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        for (int i = 0; i < levelLoader.Levels.Length; i++)
        {
            var button = Instantiate(LevelButtonPrefab, LevelGrid);
            button.GetComponent<LevelButton>().SetLevel(i);
        }
    }
}
