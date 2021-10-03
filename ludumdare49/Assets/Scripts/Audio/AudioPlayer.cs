using System.Collections;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource AudioSource;
    public int MaxSimultaneousSounds = 10;

    int playing;

    private void Start()
    {
        AudioSource = AudioSource ?? GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip audioClip)
    {
        AudioSource.clip = audioClip;
        AudioSource.loop = true;
    }

    public void PlaySound(AudioClip clip)
    {
        if (playing > MaxSimultaneousSounds)
            return;

        playing++;
        StartCoroutine(PlayClip(clip));
    }

    IEnumerator PlayClip(AudioClip clip)
    {
        AudioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        playing--;
    }
}