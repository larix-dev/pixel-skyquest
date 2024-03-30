using UnityEngine;

namespace Handlers {
public class RunePillar : HitHandler {
    public Sprite activeSprite;
    private Sprite _defaultSprite;
    private SpriteRenderer _sr;
    private bool _active;
    private AudioSource _sfx;

    public delegate void PillarAction(RunePillar sender);

    public event PillarAction OnPillarActivate;

    public void Start() {
        _sr = GetComponent<SpriteRenderer>();
        _defaultSprite = _sr.sprite;
        _sfx = GetComponent<AudioSource>();
    }

    public override void HandleHit() {
        if (_active) return;
        SetActive(true);
        _sfx.Play();
        OnPillarActivate?.Invoke(this);
    }

    public void SetActive(bool active) {
        _active = active;
        _sr.sprite = active ? activeSprite : _defaultSprite;
    }
}
}