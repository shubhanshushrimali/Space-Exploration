using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetInfoUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text sizeText;
    public TMP_Text distanceText;
    public TMP_Text orbitText;
    public TMP_Text moonText;
    public TMP_Text moonNamesText;

    public void Setup(PlanetData data)
    {
        nameText.text = $"<b>Name:</b> {data.name}";
        sizeText.text = $"<b>Diameter:</b> {data.diameter:N0} km";
        distanceText.text = $"<b>Distance from Sun:</b> {data.distanceFromSun:N1} million km";
        orbitText.text = $"<b>Orbital Period:</b> {data.orbitalPeriod:N1} Earth days";
        moonText.text = $"<b>Moons:</b> {data.numberOfMoons}";

        if (data.numberOfMoons > 0 && data.moonNames != null && data.moonNames.Length > 0)
        {
            moonNamesText.text = "<b>Moon Names:</b>\n" + string.Join(", ", data.moonNames);
        }
        else
        {
            moonNamesText.text = "<b>Moon Names:</b> None";
        }
    }
}