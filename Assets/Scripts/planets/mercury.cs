using System.Collections.Specialized;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class mercury : MonoBehaviour
{
    private Transform sphereTransform;
    
    public Vector3 sunPosition = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float orbitSpeed = 3f;


    public float distanceTotal = 75.09f;

    void Start()
    {
        sphereTransform = GetComponent<Transform>();
        if (sphereTransform == null)
        {
            Debug.LogError("Transform n�o encontrado na esfera!");
        }

        // Coloca V�nus a uma certa dist�ncia do Sol no in�cio
        transform.position = new Vector3(distanceTotal, 0, 0);
    }

    void Update()
    {
        // Faz V�nus girar ao redor do Sol
        transform.RotateAround(sunPosition, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
