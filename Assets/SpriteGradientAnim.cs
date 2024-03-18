using UnityEngine;

public class SpriteGradientAnim : MonoBehaviour {
    public Gradient gradient;
    public float time;

    private SpriteRenderer _spriteRenderer;
    private float _timer;

    private void Start() {
        _timer = time * Random.value;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (!_spriteRenderer) return;
        _timer += Time.deltaTime;
        if (_timer > time) {
            _timer = 0.0f;
        }

        _spriteRenderer.color = gradient.Evaluate(_timer / time);
    }
}