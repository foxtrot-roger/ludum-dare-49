using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    public static MenuScreen Instance { get; private set; }

    void Start()
    {
        Instance = this;
    }

    public static void OpenMainMenu()
        => OpenScreen("scr_Main");
    public static void OpenLevelsMenu()
        => OpenScreen("scr_Levels");

    public static void OpenControlsMenu()
        => OpenScreen("scr_Controls");

    public static void OpenOptionsMenu()
        => OpenScreen("scr_Options");

    public static void OpenHudMenu()
        => OpenScreen("scr_HUD");

    public static void OpenPauseMenu()
        => OpenScreen("scr_Pause");
    public static void OpenCreditsMenu()
        => OpenScreen("scr_Credits");

    public static void OpenVictoryMenu()
        => OpenScreen("scr_Victory");
    public static void OpenFailureMenu()
        => OpenScreen("scr_Failure");

    public static void OpenScreen(string menuName)
    {
        for (int i = 0; i < Instance.transform.childCount; i++)
        {
            var menu = Instance.transform.GetChild(i);
            menu.gameObject.SetActive(false);
        }

        for (int i = 0; i < Instance.transform.childCount; i++)
        {
            var menu = Instance.transform.GetChild(i);
            menu.gameObject.SetActive(menu.name == menuName);
        }
    }
}