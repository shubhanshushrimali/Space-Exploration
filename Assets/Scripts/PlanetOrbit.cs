using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public Transform sun;
    public PlanetData[] planets;

    public float sizeScale = 0.00071818f;
    public float distanceScale = 15f;
    public float moonDistanceScale = 0.1f; // For spacing moons around planets

    void Start()
    {
        foreach (var planet in planets)
        {
            if (planet.planetObject != null)
            {
                // Position planet relative to sun
                Vector3 planetPos = sun.position + new Vector3(planet.distanceFromSun * distanceScale, 0, 0);
                planet.planetObject.transform.position = planetPos;

                // Scale planet
                float planetScale = planet.diameter * sizeScale;
                planet.planetObject.transform.localScale = Vector3.one * planetScale;

                // Spawn moons
                for (int i = 0; i < planet.numberOfMoons; i++)
                {
                    GameObject moon = Instantiate(planet.moonPrefab);
                    moon.name = $"{planet.name}_Moon_{i + 1}";
                    moon.transform.SetParent(planet.planetObject.transform); // Parent to planet

                    // Distance from planet
                    float moonDistance = planet.moonOrbitDistances[i] * moonDistanceScale;

                    // Set position relative to planet
                    moon.transform.localPosition = new Vector3(moonDistance, 0, 0);

                    // Scale moon
                    float moonScale = planet.moonDiameters[i] * sizeScale;
                    moon.transform.localScale = Vector3.one * moonScale;

                    // Optional: Add MoonOrbit script to rotate around planet
                    moon.AddComponent<MoonOrbit>().Setup(planet.planetObject.transform, moonDistance);
                }
            }
        }
    }

    void Update()
    {
        foreach (var planet in planets)
        {
            if (planet.planetObject == null) continue;

            // Rotate on own axis
            planet.planetObject.transform.Rotate(Vector3.up, planet.rotationSpeed * Time.deltaTime);

            // Orbit around sun
            float angle = (360f / planet.orbitalPeriod) * Time.deltaTime;
            planet.planetObject.transform.RotateAround(sun.position, Vector3.up, angle);
        }
    }
}