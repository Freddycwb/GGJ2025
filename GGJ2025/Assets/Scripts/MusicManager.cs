using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] musics;
    [SerializeField] private float volumeSpeed;
    [SerializeField] private AudioSource currentMusic;

    private Coroutine lowing;
    private Coroutine highing;

    private void Start()
    {
        currentMusic = musics[0];
    }

    public void SwitchIntensity(int value)
    {
        if (lowing != null)
        {
            StopCoroutine(lowing);
        }
        if (highing != null)
        {
            StopCoroutine(highing);
        }

        lowing = StartCoroutine(TurnVolumeDown(currentMusic));
        highing = StartCoroutine(TurnVolumeUp(musics[value]));

        currentMusic = musics[value];
    }

    private IEnumerator TurnVolumeDown(AudioSource audio)
    {
        int i = 0;
        while (audio.volume > 0)
        {
            audio.volume -= volumeSpeed;
            i++;
            if (i > 1000)
            {
                audio.volume = 0;
                break;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator TurnVolumeUp(AudioSource audio)
    {
        int i = 0;
        while (audio.volume < 1)
        {
            Debug.Log(audio.volume);
            audio.volume += volumeSpeed;
            Debug.Log(audio.volume);
            i++;
            if (i > 1000)
            {
                audio.volume = 1;
                break;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
