using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public static GameAudio Instance { get; private set; }

    public AudioPlayer Music;
    public AudioPlayer SFX;
    public AudioPlayer UI;

    void Start()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public static void PlayMusic(AudioClip audioClip)
        => Instance?.Music?.PlayMusic(audioClip);

    public static void PlayEffect(AudioClip audioClip)
        => Instance?.SFX?.PlaySound(audioClip);

    public static void PlayUI(AudioClip audioClip)
        => Instance?.UI?.PlaySound(audioClip);
}
