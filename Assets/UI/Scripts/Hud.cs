using TMPro;
using UnityEngine;

namespace UI.Scripts {
public class Hud : MonoBehaviour {
    public int floorNumber;
    public string floorName;
    public TextMeshProUGUI levelDisplay;

    public void Start() {
        levelDisplay.SetText($"Floor {floorNumber}: {floorName}");
    }
}
}