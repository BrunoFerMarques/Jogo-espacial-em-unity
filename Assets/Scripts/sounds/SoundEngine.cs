using UnityEngine;
    
public class SoundEngine : MonoBehaviour
{
    public SpaceshipController spaceshipController;
    public AudioSource audioSource;

    public float minVol = 0f;
    public float maxVol = 0.8f;
    public float minPitch = 0.8f;     // Pitch mínimo
    public float maxPitch = 2.0f;     // Pitch máximo
    public float maxSpeed = 100f;     // Velocidade máxima da nave (para normalizar)
    
    void Start()
    {
        // Inicialmente, configura o volume e pitch mínimos
        audioSource.volume = minVol;
        audioSource.pitch = minPitch;

        // Começa a tocar o som se não estiver tocando
        if (!audioSource.isPlaying)
        {
            audioSource.loop = true; // Deixa o som em loop
            audioSource.Play();
        }
    }

    void Update()
    {
        
        if (!audioSource.isPlaying)
        {
            audioSource.loop = true; 
            audioSource.Play();
        }
    
        float speed = spaceshipController.currentSpeed;

        // Normaliza a velocidade (0 ~ 1)
        float normalizedSpeed = Mathf.Clamp01(speed / maxSpeed);

        // Atualiza volume e pitch de forma suave
        audioSource.volume = Mathf.Lerp(minVol, maxVol, normalizedSpeed);
        audioSource.pitch = Mathf.Lerp(minPitch, maxPitch, normalizedSpeed);
    }
    

}

