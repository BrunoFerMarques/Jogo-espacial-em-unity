using UnityEngine;

public class AudioSequencePlayer : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip[] audioClips; // Arraste aqui as 5 faixas no Inspector

    private int currentClipIndex = 0;

    void Start()
    {
        if (audioClips.Length > 0)
        {
            PlayNextClip();
        }
    }

    void Update()
    {
        // Quando a música atual acabar, toca a próxima
        if (!audioSource.isPlaying && currentClipIndex < audioClips.Length)
        {
            PlayNextClip();
        }
    }

    void PlayNextClip()
    {
        if (currentClipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
            currentClipIndex++;
        }
    }
}
