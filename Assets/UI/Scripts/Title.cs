using UnityEditor;
using UnityEngine;

namespace UI.Scripts {
public class Title : MonoBehaviour {
    public void Exit() {
        if (Application.isEditor) {
            EditorApplication.isPlaying = false;
        } else {
            Application.Quit();
        }
    }
}
}