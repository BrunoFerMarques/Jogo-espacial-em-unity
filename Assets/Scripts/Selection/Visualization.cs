using UnityEngine;

public class SpaceshipVisualize : MonoBehaviour
{
    [Header("Rotação")]
    private float rotationSpeed = 30f; // Graus por segundo
    private Vector3 position = new Vector3(0f, 0f, -30f);
    void Update()
    {
        // Gira o modelo continuamente no eixo Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        transform.position = position;
    }
}