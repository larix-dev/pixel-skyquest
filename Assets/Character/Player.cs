using UnityEngine;

namespace Character {
public class Player : MonoBehaviour {
    private Animator _anim;
    private Rigidbody2D _rigidbody;

    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int Running = Animator.StringToHash("Running");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private const float Speed = 150.0f;

    public void Awake() {
        _anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
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
        }

        _anim.SetBool(Walking, movement.magnitude > 0 && Input.GetKey(KeyCode.LeftShift));
        _anim.SetBool(Running, movement.magnitude > 0 && !Input.GetKey(KeyCode.LeftShift));

        if (Input.GetKeyDown(KeyCode.Space)) {
            _anim.SetTrigger(Jump);
        }

        if (Input.GetMouseButtonDown(1)) {
            _anim.SetTrigger(Attack);
        }
    }
}
}