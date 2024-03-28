using UnityEngine;

namespace Handlers {
public class RunePillar : HitHandler {
    public Sprite activeSprite;
    private Sprite _defaultSprite;
    private SpriteRenderer _sr;
    private bool _active;

    public delegate void PillarAction(RunePillar sender);

    public event PillarAction OnPillarActivate;

    public void Start() {
        _sr = GetComponent<SpriteRenderer>();
        _defaultSprite = _sr.sprite;
    }

    public override void HandleHit() {
        if (_active) return;
        SetActive(true);
        OnPillarActivate?.Invoke(this);
    }

    public void SetActive(bool active) {
        _active = active;
        _sr.sprite = active ? activeSprite : _defaultSprite;
    }
}
}