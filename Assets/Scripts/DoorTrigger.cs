using UnityEngine;

public class DoorTrigger : MonoBehaviour {
    public GameObject lockedDoor;
    public GameObject openDoor;

    private Player _player;

    private void Start() {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && _player.HasKey) {
            lockedDoor.SetActive(false);
            openDoor.SetActive(true);
            _player.SetHasKey(false);
        }
    }
}