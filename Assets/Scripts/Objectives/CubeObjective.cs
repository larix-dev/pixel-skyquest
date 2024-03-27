using UnityEngine;

namespace Objectives {
public class CubeObjective : Objective {
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Cube")) {
            SetComplete();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Cube")) {
            SetIncomplete();
        }
    }
}
}