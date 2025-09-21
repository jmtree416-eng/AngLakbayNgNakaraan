using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 400f;

    Rigidbody2D rb;
    Vector2 moveInput;
    bool grounded = true;

    PlayerInputActions controls; // <-- updated class name

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controls = new PlayerInputActions(); // <-- updated class name

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Jump.performed += ctx => {
            if (grounded)
            {
                rb.AddForce(Vector2.up * jumpForce);
                grounded = false;
            }
        };
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        foreach (var c in other.contacts)
            if (c.normal.y > 0.5f) grounded = true;
    }
}