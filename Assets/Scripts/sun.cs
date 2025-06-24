using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;


public class Sun : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f; // Velocidade de rotação em graus por segundo
    void Start()
    {
        PlanetData sun = SolarSystemData.Planets["Sun"];
        transform.localScale = Vector3.one * (float)sun.RadiusKm;
        transform.Translate(0, 0, 0);

    }
    void Update()
    {
        // Rotaciona o objeto em torno do seu próprio eixo Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}