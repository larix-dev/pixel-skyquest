using UnityEngine;

public class DoorTrigger : MonoBehaviour {
    public GameObject door;
    public GameObject openDoor;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            door.SetActive(false);
            openDoor.SetActive(true);
        }
    }
}