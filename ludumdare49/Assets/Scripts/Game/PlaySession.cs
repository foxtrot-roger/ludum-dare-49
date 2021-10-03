using UnityEngine;

public class PlaySession : MonoBehaviour
{
    int currentLevel = 0;

    Game game;
    LevelLoader levelLoader;

    private void Start()
    {
        game = FindObjectOfType<Game>();
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    public void NewGame()
    {
        LevelLoader.StartLevel(currentLevel);
    }
    public void StartLevel(int level)
    {
        currentLevel = level;
        Time.timeScale = 1;
        LevelLoader.StartLevel(level);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void ContinueGame()
    {
        if (levelLoader.Levels.Length > currentLevel + 1)
            StartLevel(currentLevel + 1);
        else
            game.CreditsMenu();
    }
    public void RetryGame()
    {
        StartLevel(currentLevel);
    }
    public void StopGame()
    {
        LevelLoader.StopLevel();
    }
}