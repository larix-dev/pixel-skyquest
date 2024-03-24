using TMPro;
using UnityEngine;

namespace UI {
public class Hud : MonoBehaviour {
    public string levelName;
    public TextMeshProUGUI levelDisplay;

    public void Start() {
        levelDisplay.SetText(levelName);
    }
}
}