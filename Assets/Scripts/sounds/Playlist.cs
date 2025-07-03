using UnityEngine;
using UnityEngine.InputSystem;
public class AudioSequencePlayer : MonoBehaviour
{
   
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public bool loopSequence = true;
    public KeyCode nextKey = KeyCode.RightArrow; // Tecla para próxima faixa
    public KeyCode prevKey = KeyCode.LeftArrow;  // Tecla para faixa anterior

    private int currentClipIndex = 0;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioClips.Length > 0 && audioSource != null)
        {
            PlayCurrentClip();
        }
    }

    void Update()
    {
        if (audioSource == null || audioClips.Length == 0) return;

        var keyboard = Keyboard.current; // Acesso ao teclado

        if (keyboard.rightArrowKey.wasPressedThisFrame) // Seta direita
        {
            PlayNextClip();
        }
        else if (keyboard.leftArrowKey.wasPressedThisFrame) // Seta esquerda
        {
            PlayPreviousClip();
        }
        // Controle automático ao terminar a faixa
        else if (!audioSource.isPlaying)
        {
            if (currentClipIndex < audioClips.Length - 1 || loopSequence)
            {
                PlayNextClip();
            }
        }
    }

    void PlayNextClip()
    {
        currentClipIndex++;
        if (loopSequence && currentClipIndex >= audioClips.Length)
        {
            currentClipIndex = 0;
        }
        PlayCurrentClip();
    }

    void PlayPreviousClip()
    {
        currentClipIndex--;
        if (currentClipIndex < 0)
        {
            currentClipIndex = loopSequence ? audioClips.Length - 1 : 0;
        }
        PlayCurrentClip();
    }

    void PlayCurrentClip()
    {
        if (currentClipIndex >= 0 && currentClipIndex < audioClips.Length)
        {
            audioSource.Stop();
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
            Debug.Log($"Tocando faixa {currentClipIndex + 1}/{audioClips.Length}: {audioClips[currentClipIndex].name}");
        }
    }

    void OnDisable()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}