using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    Game game;
    MenuAudio menuAudio;
    Button button;
    int Level;

    public Text Text;

    void Start()
    {
        game = FindObjectOfType<Game>();

        menuAudio = FindObjectOfType<MenuAudio>();

        button = GetComponent<Button>();
        button.onClick.AddListener(StartLevel);
    }

    public void SetLevel(int level)
    {
        Level = level;
        Text.text = level.ToString("00");
    }

    void StartLevel()
    {
        game.PlayLevel(Level);
    }

    public void Hover()
    {
        menuAudio.Hover();
    }
    public void Click()
    {
        menuAudio.Click();
    }
}
