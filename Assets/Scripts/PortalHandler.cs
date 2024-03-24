using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalHandler : MonoBehaviour {
    public string dest;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            SceneManager.LoadSceneAsync(dest);
        }
    }
}