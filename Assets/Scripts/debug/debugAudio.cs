using UnityEngine;

public class AudioSourceFinder : MonoBehaviour
{
    [System.Obsolete]
    void Start()
    {
        AudioSource[] sources = FindObjectsOfType<AudioSource>();
        foreach (var src in sources)
        {
            Debug.Log("AudioSource encontrado em: " + src.gameObject.name);
        }
    }
}
