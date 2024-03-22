using UnityEngine;

namespace Handlers {
public class PillarHitHandler : HitHandler {
    private SpriteRenderer _glow;
    private Color _curColor;
    private Color _targetColor;

    public void Awake() {
        _glow = Helpers.FindChild(gameObject, "Glow").GetComponent<SpriteRenderer>();
        _glow.enabled = false;
    }

    public override void HandleHit() {
        Debug.Log("Handling the pillar hit!");
        // _targetColor = new Color(1, 1, 1, 1);
        _glow.enabled = true;
    }
    
    // Commented out code left in in case we want to lerp the colours in the future
    // public void Start() {
    //     _targetColor = new Color(1, 1, 1, 0);
    // }
    //
    // public void Update() {
    //     _curColor = Color.Lerp(_curColor, _targetColor, lerpSpeed * Time.deltaTime);
    //
    //     foreach (var r in runes) {
    //         r.color = _curColor;
    //     }
    // }
}
}