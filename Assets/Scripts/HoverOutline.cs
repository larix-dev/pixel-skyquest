using UnityEngine;

public class HoverOutline : MonoBehaviour {
    private SpriteRenderer _renderer;
    private Material _default;
    private Material _outline;

    private void Start() {
        _renderer = GetComponent<SpriteRenderer>();
        _default = _renderer.material;
        _outline = new Material(Shader.Find("Unlit/PixelOutline"));
    }

    private void OnMouseEnter() {
        _renderer.material = _outline;
    }

    private void OnMouseExit() {
        _renderer.material = _default;
    }
}