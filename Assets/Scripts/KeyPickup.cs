using UnityEngine;

public class KeyPickup : MonoBehaviour {
    private Player _player;

    private void Start() {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            _player.SetHasKey(true);
            Destroy(gameObject);
        }
    }
}