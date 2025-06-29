
using Unity.Mathematics;
using UnityEngine;

public class PositionFire : MonoBehaviour
{
    public SpaceshipController spaceship;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = spaceship.transform.position;
        Quaternion rotation = spaceship.transform.rotation;
        transform.rotation = new Quaternion(rotation.x, rotation.y, rotation.z, 1);
        transform.position = new Vector3(position.x, position.y , position.z-1.5f);
        
    }
}
