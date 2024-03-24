using UnityEngine;

public class CubeHandler : MonoBehaviour {
    private AudioSource _audioSource;
    private Rigidbody2D _rigidbody;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (_rigidbody.velocity.magnitude > 0.1f && !_audioSource.isPlaying) {
            Helpers.PlayVar(_audioSource, this);
        }
    }
}