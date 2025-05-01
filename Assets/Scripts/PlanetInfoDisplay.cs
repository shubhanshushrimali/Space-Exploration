using UnityEngine;

public class PlanetInfoDisplay : MonoBehaviour
{
    public PlanetData data;
    public GameObject uiPrefab; // assign a world-space canvas prefab
    private GameObject spawnedUI;

    public void ShowInfo()
    {
        if (spawnedUI == null)
        {
            spawnedUI = Instantiate(uiPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);
            PlanetInfoUI ui = spawnedUI.GetComponent<PlanetInfoUI>();
            ui.Setup(data);
        }
    }

    public void HideInfo()
    {
        if (spawnedUI != null)
        {
            Destroy(spawnedUI);
        }
    }
}