using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI {
public class ButtonHandler : MonoBehaviour {
    public void Exit() {
        if (Application.isEditor) {
            EditorApplication.isPlaying = false;
        } else {
            Application.Quit();
        }
    }

    public void LoadScene(string scene) {
        SceneManager.LoadSceneAsync(scene);
    }
}
}