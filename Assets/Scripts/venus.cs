using UnityEngine;

public class Venus : MonoBehaviour
{
    void Start()
    {
        // 1. Acessa os dados do Sol e de Vênus
        PlanetData sunData = SolarSystemData.Planets["Sun"];
        PlanetData venusData = SolarSystemData.Planets["Venus"];

        // 2. Soma o raio do Sol com a distância de Vênus ao Sol
        float totalDistance = (float)(sunData.RadiusKm + venusData.DistanceFromSunKm);


        // 4. Posiciona Vênus na distância calculada

        transform.position = new Vector3(totalDistance, 0, 0);

    }
    public float orbitSpeed = 2f;
    public Vector3 sunPosition = Vector3.zero;
    void Update()
    {
        transform.RotateAround(sunPosition, Vector3.up, orbitSpeed * Time.deltaTime);    
    }
}