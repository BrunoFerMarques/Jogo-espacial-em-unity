using UnityEngine;

public class PositionFire : MonoBehaviour
{
    public SpaceshipController spaceship;
    public Vector3 localOffset = new Vector3(0, -1f, -6f);

    void Update()
    {
        // Calcula a posição global do fogo a partir do offset local
        transform.position = spaceship.transform.TransformPoint(localOffset);

        // Copia a rotação da nave
        transform.rotation = spaceship.transform.rotation;
    }
}
