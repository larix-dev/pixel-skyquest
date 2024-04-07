using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CameraHandler : MonoBehaviour {
    public Transform target;

    private const float MinZoom = 0.5f;
    private const float MaxZoom = 1.5f;
    private const float ZoomSpeed = 5f;

    private PixelPerfectCamera _camera;
    private float _zoomLevel = 1f;
    private float _z;
    private Vector2 _res;

    private void Start() {
        _camera = GetComponent<PixelPerfectCamera>();
        _res = new Vector2(_camera.refResolutionX, _camera.refResolutionY);
        _z = transform.position.z;
    }

    private void Update() {
        var delta = -Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
        if (delta == 0) return;
        _zoomLevel = Mathf.Clamp(_zoomLevel + delta, MinZoom, MaxZoom);
        ResizeCamera();
    }

    private void ResizeCamera() {
        var res = _res * _zoomLevel;
        _camera.refResolutionX = Mathf.RoundToInt(res.x);
        _camera.refResolutionY = Mathf.RoundToInt(res.y);
    }

    private void OnRectTransformDimensionsChange() {
        ResizeCamera();
    }

    private void LateUpdate() {
        var pos = target.position;
        transform.position = new Vector3(pos.x, pos.y, _z);
    }
}