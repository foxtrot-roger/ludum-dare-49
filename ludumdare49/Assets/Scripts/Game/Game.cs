using UnityEngine;

public class Game : MonoBehaviour
{
    PlaySession playSession;
    GameState gameState;

    private void Start()
    {
        playSession = GetComponent<PlaySession>();
    }

    public void Play()
    {
        gameState = GameState.Play;

        MenuScreen.OpenHudMenu();
        playSession.NewGame();
    }
    public void PlayLevel(int level)
    {
        gameState = GameState.Play;

        MenuScreen.OpenHudMenu();
        playSession.StartLevel(level);
    }
    public void Pause()
    {
        gameState = GameState.Pause;

        MenuScreen.OpenPauseMenu();
        playSession.PauseGame();
    }
    public void Resume()
    {
        gameState = GameState.Play;

        MenuScreen.OpenHudMenu();
        playSession.ResumeGame();
    }
    public void Continue()
    {
        gameState = GameState.Play;

        MenuScreen.OpenHudMenu();
        playSession.ContinueGame();
    }
    public void Retry()
    {
        gameState = GameState.Play;

        MenuScreen.OpenHudMenu();
        playSession.RetryGame();
    }

    public void MainMenu()
    {
        gameState = GameState.Menu;

        MenuScreen.OpenMainMenu();
        playSession.StopGame();
    }
    public void LevelMenu()
    {
        gameState = GameState.Menu;

        MenuScreen.OpenLevelsMenu();
        playSession.StopGame();
    }
    public void OptionsMenu()
    {
        gameState = GameState.Menu;

        MenuScreen.OpenOptionsMenu();
        playSession.StopGame();
    }
    public void ControlsMenu()
    {
        gameState = GameState.Menu;

        MenuScreen.OpenControlsMenu();
        playSession.StopGame();
    }
    public void CreditsMenu()
    {
        gameState = GameState.Menu;

        MenuScreen.OpenCreditsMenu();
        playSession.StopGame();
    }

    public void VictoryMenu()
    {
        gameState = GameState.Menu;

        MenuScreen.OpenVictoryMenu();
        playSession.StopGame();
    }
    public void FailureMenu()
    {
        gameState = GameState.Menu;

        MenuScreen.OpenFailureMenu();
        playSession.StopGame();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
