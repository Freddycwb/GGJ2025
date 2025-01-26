using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private Vector2 pitchRange;

    public void playAudio()
    {
        audioSource.pitch = Random.Range(pitchRange.x, pitchRange.y);
        if (audioClips.Length > 0)
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        }
        audioSource.Play();
    }

    public void playAudio(IntVariable value)
    {
        audioSource.pitch = Mathf.Clamp(((50.0f - value.Value) / 50.0f) * (pitchRange.y - pitchRange.x) + pitchRange.x, pitchRange.x, pitchRange.y);
        audioSource.Play();
    }
}
