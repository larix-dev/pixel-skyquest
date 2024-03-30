using UnityEngine;

public class DoorTrigger : MonoBehaviour {
    public GameObject lockedDoor;
    public GameObject openDoor;

    private Player _player;
    private AudioSource _sfx;

    private void Start() {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _sfx = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && _player.HasKey) {
            lockedDoor.SetActive(false);
            openDoor.SetActive(true);
            _player.SetHasKey(false);
            _sfx.Play();
        }
    }
}