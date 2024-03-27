using UnityEngine;

namespace Objectives {
public class JumpObjective : Objective {
    public int jumps;

    private int _jumpsCompleted;
    private Player _player;


    private void Start() {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _player.OnJump += HandleJump;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _player.OnJump -= HandleJump;
            _jumpsCompleted = 0;
        }
    }

    private void HandleJump() {
        _jumpsCompleted++;
        if (_jumpsCompleted >= jumps) {
            SetComplete();
            Destroy(gameObject);
        }
    }
}
}