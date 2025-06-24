
using System;
using System.Collections.Generic;  // Adicione esta linha
using UnityEngine;  // Se estiver usando funcionalidades do Unity
public static class SolarSystemData
{
    public static readonly Dictionary<string, PlanetData> Planets = new Dictionary<string, PlanetData>
    {
        {
            "Mercury",
            new PlanetData
            {
                Name = "Mercury",
                RadiusKm = 4.8,
                DistanceFromSunAu = PlanetData.KmToAu(5.791),
                DistanceFromSunKm = 5.791,
            }
        },
        {
            "Sun",
            new PlanetData{
                Name = "Sun",
                RadiusKm = 140,
                DistanceFromSunAu = 0,
                DistanceFromSunKm = 0,
            }

        },
        {
            "Venus",
            new PlanetData
            {
                Name = "Venus",
                RadiusKm = 12.103,
                DistanceFromSunAu = PlanetData.KmToAu(10.82),
                DistanceFromSunKm = 10.82
            }
        },
        {
            "Earth",
            new PlanetData
            {
                Name = "Earth",
                RadiusKm = 12.756,
                DistanceFromSunAu = PlanetData.KmToAu(14.96),
                DistanceFromSunKm = 14.96,
            }
        },
        {
            "Mars",
            new PlanetData
            {
                Name = "Mars",
                RadiusKm = 6.7,
                DistanceFromSunAu = PlanetData.KmToAu(22.792),
                DistanceFromSunKm = 22.792,
            }
        },
        {
            "Jupiter",
            new PlanetData
            {
                Name = "Jupiter",
                RadiusKm = 140,
                DistanceFromSunAu = PlanetData.KmToAu(78),
                DistanceFromSunKm = 78,
            }
        },
        {
            "Saturn",
            new PlanetData
            {
                Name = "Saturn",
                RadiusKm = 120,
                DistanceFromSunAu = PlanetData.KmToAu(143),
                DistanceFromSunKm = 143,
            }
        },
        {
            "Uranus",
            new PlanetData
            {
                Name = "Uranus",
                RadiusKm = 51.800,
                DistanceFromSunAu = PlanetData.KmToAu(143),
                DistanceFromSunKm = 280,
            }
        },
    };

    // Você pode adicionar métodos úteis também
    public static double GetPlanetRadius(string planetName)
    {
        if (Planets.TryGetValue(planetName, out var planet))
            return planet.RadiusKm;
        throw new ArgumentException($"Planet '{planetName}' not found");
    }

    public static string GetFormattedPlanetInfo(string planetName)
    {
        if (!Planets.ContainsKey(planetName))
            return $"Planet '{planetName}' not founded";

        var planet = Planets[planetName];
        return $"{planet.Name}: Raio = {planet.RadiusKm:N0} km, Distância do Sol = {planet.DistanceFromSunAu:N2} UA ({planet.DistanceFromSunKm:N0} km)";
    }
}