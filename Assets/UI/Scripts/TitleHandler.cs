using UnityEditor;
using UnityEngine;

namespace UI.Scripts {
public class ButtonHandler : MonoBehaviour {
    public void Exit() {
        if (Application.isEditor) {
            EditorApplication.isPlaying = false;
        } else {
            Application.Quit();
        }
    }
}
}