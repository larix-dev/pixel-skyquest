using UnityEditor;
using UnityEngine;

namespace UI.Scripts {
public class Title : MonoBehaviour {
    public void Exit() {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
}