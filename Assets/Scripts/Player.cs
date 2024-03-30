using System.Collections.Generic;
using Handlers;
using UnityEngine;

public class Player : MonoBehaviour {
    private Animator _anim;
    private Rigidbody2D _rigidbody;

    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int Running = Animator.StringToHash("Running");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Blink = Animator.StringToHash("Blink");

    private const float Speed = 150.0f;
    private const float AttackDuration = 0.35f;
    private const float JumpDuration = 0.5f;
    
    private float _nextBlinkTime;

    private BoxCollider2D _attackTrigger;
    private bool _canAttack = true;
    private bool _canJump = true;
    
    private AudioSource _audioSource;

    public AudioClip[] attackSounds;
    public AudioSource walkSound;

    public delegate void JumpAction();

    public event JumpAction OnJump;

    public delegate void KeyAction(bool hasKey);

    public event KeyAction KeyEvent;

    public bool HasKey { get; private set; }

    public void Awake() {
        _anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _nextBlinkTime = GetNextBlinkTime();
        _attackTrigger = GetComponents<BoxCollider2D>()[1];
        _attackTrigger.enabled = false;
        _audioSource = GetComponent<AudioSource>();
    }

    private float GetNextBlinkTime() {
        return Time.time + Random.Range(3f, 7f);
    }

    public void Update() {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        var movement = new Vector2(h, v).normalized;
        var velocity = movement * (Speed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.LeftShift)) {
            velocity *= 0.5f;
        }

        _rigidbody.velocity = velocity;

        if (movement.magnitude > 0) {
            _anim.SetFloat(Horizontal, movement.x);
            _anim.SetFloat(Vertical, movement.y);
            PlayWalkSound();
        }

        _anim.SetBool(Walking, movement.magnitude > 0 && Input.GetKey(KeyCode.LeftShift));
        _anim.SetBool(Running, movement.magnitude > 0 && !Input.GetKey(KeyCode.LeftShift));

        if (Input.GetKeyDown(KeyCode.Space) && _canJump) {
            _anim.SetTrigger(Jump);
            OnJump?.Invoke();
            _canJump = false;
            StartCoroutine(JumpTimer());
        }

        if (Input.GetMouseButtonDown(1) && _canAttack) {
            _anim.SetTrigger(Attack);
            PlayAttackSound();
            _attackTrigger.enabled = true;
            _canAttack = false;
            StartCoroutine(AttackTimer());
        }

        if (Time.time >= _nextBlinkTime) {
            _anim.SetTrigger(Blink);
            _nextBlinkTime = GetNextBlinkTime();
        }
    }

    private void PlayWalkSound() {
        if (!walkSound.isPlaying) {
            Helpers.PlayVar(walkSound, this);
        }
    }

    private void PlayAttackSound() {
        _audioSource.clip = attackSounds[Random.Range(0, attackSounds.Length)];
        Helpers.PlayVar(_audioSource, this);
    }

    private IEnumerator<WaitForSeconds> AttackTimer() {
        yield return new WaitForSeconds(AttackDuration);
        _attackTrigger.enabled = false;
        _canAttack = true;
    }

    private IEnumerator<WaitForSeconds> JumpTimer() {
        yield return new WaitForSeconds(JumpDuration);
        PlayWalkSound();
        _canJump = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        _attackTrigger.enabled = false;
        var hitHandler = other.GetComponent<HitHandler>();
        if (hitHandler != null) {
            hitHandler.HandleHit();
        }
    }

    public void SetHasKey(bool hasKey) {
        HasKey = hasKey;
        KeyEvent?.Invoke(hasKey);
    }
}