// PlanetData.cs
using UnityEngine;

[System.Serializable]  // Adicione se quiser serializar no Inspector
public class PlanetData
{
    // Propriedades públicas (ou pelo menos com getters públicos)
    public string Name { get; set; }
    public double RadiusKm { get; set; }  // Esta é a propriedade faltante
    public double DistanceFromSunAu { get; set; }
    public double DistanceFromSunKm { get; set; }

    // Métodos de conversão
    public static double AuToKm(double au) => au * 149_597_870.7;
    public static double KmToAu(double km) => km / 149_597_870.7;
}