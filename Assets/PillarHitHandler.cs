using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PillarHitHandler : HitHandler {

    public SpriteRenderer glow;

    private Color _curColor;
    private Color _targetColor;

    public void Start() {
        glow.enabled = false;
    }

    public override void HandleHit() {
        Debug.Log("Handling the pillar hit!");
       // _targetColor = new Color(1, 1, 1, 1);
       glow.enabled = true;
    }

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