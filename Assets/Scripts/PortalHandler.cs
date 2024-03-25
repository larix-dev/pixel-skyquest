using UnityEngine;

public class PortalHandler : MonoBehaviour {
    public string dest;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            GameObject.Find("SceneLoader").GetComponent<SceneLoader>().LoadScene(dest);
        }
    }
}