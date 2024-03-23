using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;

    private float _z;

    private void Start() {
        _z = transform.position.z;
    }

    private void LateUpdate() {
        var pos = target.position;
        transform.position = new Vector3(pos.x, pos.y, _z);
    }
}