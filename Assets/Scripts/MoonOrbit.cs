using UnityEngine;

public class MoonOrbit : MonoBehaviour
{
    private Transform center;
    private float orbitDistance;
    public float orbitSpeed = 30f;

    public void Setup(Transform center, float distance)
    {
        this.center = center;
        this.orbitDistance = distance;
    }

    void Update()
    {
        if (center == null) return;
        transform.RotateAround(center.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}