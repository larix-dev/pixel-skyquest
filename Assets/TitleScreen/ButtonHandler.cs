using UnityEditor;
using UnityEngine;

namespace TitleScreen {
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