using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    private const float LerpSpeed = 3.0f;

    private Vector3 _offset;
    private Vector3 _targetPos;

    private void Start() {
        _offset = transform.position - target.position;
    }

    private void LateUpdate() {
        _targetPos = target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, _targetPos, LerpSpeed * Time.deltaTime);
    }
}