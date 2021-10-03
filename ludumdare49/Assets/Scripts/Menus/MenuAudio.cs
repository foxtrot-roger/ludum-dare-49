using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public AudioClip HoverClip;
    public AudioClip ClickClip;
    public AudioClip BackClip;

    public void Hover()
        => GameAudio.PlayUI(HoverClip);

    public void Click()
        => GameAudio.PlayUI(ClickClip);

    public void Back()
        => GameAudio.PlayUI(BackClip);
}
