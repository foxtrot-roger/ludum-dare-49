using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;

    public AudioClip SFXClip;
    public AudioClip MenuClip;

    public void SetMainVolume(float value)
    {
        AudioMixer.SetFloat("Music", value);
    }
    public void SetSFXVolume(float value)
    {
        AudioMixer.SetFloat("SFX", value);
        GameAudio.PlayEffect(SFXClip);
    }
    public void SetMenuVolume(float value)
    {
        AudioMixer.SetFloat("UI", value);
        GameAudio.PlayUI(MenuClip);
    }
}