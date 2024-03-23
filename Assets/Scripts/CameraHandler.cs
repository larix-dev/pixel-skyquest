using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CameraHandler : MonoBehaviour {
    public Transform target;

    private const float MinZoom = 1f;
    private const float MaxZoom = 5f;
    private const float ZoomSpeed = 10f;

    private PixelPerfectCamera _camera;
    private float _zoomLevel = 1f;
    private float _z;

    private void Start() {
        _camera = GetComponent<PixelPerfectCamera>();
        _z = transform.position.z;
    }

    private void Update() {
        var delta = Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
        if (delta == 0) return;
        _zoomLevel = Mathf.Clamp(_zoomLevel + delta, MinZoom, MaxZoom);
        ResizeCamera();
    }

    private void ResizeCamera() {
        _camera.refResolutionX = Mathf.FloorToInt(Screen.width / _zoomLevel);
        _camera.refResolutionY = Mathf.FloorToInt(Screen.height / _zoomLevel);
    }

    private void OnRectTransformDimensionsChange() {
        ResizeCamera();
    }

    private void LateUpdate() {
        var pos = target.position;
        transform.position = new Vector3(pos.x, pos.y, _z);
    }
}