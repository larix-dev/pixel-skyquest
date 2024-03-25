using System.Linq;
using UnityEngine;

public class OpacityTrigger : MonoBehaviour {
    private SpriteRenderer[] _srs;
    private GameObject _player;
    private float _targetOpacity;

    private const float LerpSpeed = 0.025f;
    private const float ContractAmount = 2f;

    private void Start() {
        _srs = GetComponentsInChildren<SpriteRenderer>();
        _player = GameObject.FindWithTag("Player");
    }

    private void Update() {
        var inBounds = _srs.Any(sr => ContractX(sr.bounds).Contains(_player.transform.position));
        _targetOpacity = inBounds ? 0.5f : 1f;

        foreach (var sr in _srs) {
            var color = sr.color;
            color.a = Mathf.Lerp(color.a, _targetOpacity, LerpSpeed);
            sr.color = color;
        }
    }

    private static Bounds ContractX(Bounds bounds) {
        bounds.extents -= new Vector3(ContractAmount / 32f, 0, 0);
        return bounds;
    }
}