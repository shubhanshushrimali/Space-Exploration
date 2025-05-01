using UnityEngine;

[System.Serializable]
public class PlanetData
{
    public string name;
    public GameObject planetObject;
    public float distanceFromSun; // In million km, scaled
    public float orbitalPeriod;   // In Earth days
    public float rotationSpeed;   // Degrees per second
    public float diameter;


    public int numberOfMoons;
    public string[] moonNames;
    public float[] moonDiameters;         // In km
    public float[] moonOrbitDistances;    // In 1000 km
    public GameObject moonPrefab;
}