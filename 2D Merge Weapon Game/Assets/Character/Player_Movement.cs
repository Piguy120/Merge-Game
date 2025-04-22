using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float downwardForce = 5f;
    private Rigidbody2D rb;
    public bool isGrounded;
    public float friction = 0.9f;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D groundCollider;
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        if (isGrounded && Input.GetAxis("Horizontal") == 0)
        {
            rb.linearVelocity *= friction;
        }

        // Check if the player is at the top of the jump
        if (!isGrounded && rb.linearVelocity.y <= 0)
        {
            rb.AddForce(new Vector2(0f, -downwardForce), ForceMode2D.Impulse);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    void Move()
    {
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

        // Stop the jump when the jump button is released
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }
}
