using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private float doubleJumpingPower = 10f;
    public bool isFacingRight { get; private set; } = false;

    private bool doubleJump;
    private bool canDoubleJump = false;

    private bool canGrapple = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask grappleLayer;

    private GrapplingHook grapplingHook;

    public PlayerInventory inventory;

    private void Start()
    {
        EnablePlayerMovement();
        grapplingHook = GetComponent<GrapplingHook>();
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;

        Flip();
    }
    public void Jump(InputAction.CallbackContext context) 
    {

        if (context.performed && IsGrounded())
        {
            doubleJump = false;
        }

        if (context.performed && (IsGrounded() || doubleJump && canDoubleJump))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, doubleJump ? doubleJumpingPower : jumpingPower);

            doubleJump = !doubleJump;
        }

        if (context.canceled && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

    }

    public void UseGrapplingHook(InputAction.CallbackContext context)
    {

        if (context.performed && IsGrounded() && canGrapple && !grapplingHook.isGrappling)
        {
            Debug.Log("Use Grapple");
            grapplingHook.StartGrapple();
        }
    }

    private void FixedUpdate()
    {
        if (!grapplingHook.retracting && !grapplingHook.isGrappling)
            rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        else
            rb.linearVelocity = Vector2.zero;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(groundcheck.position, 0.2f, grappleLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    public void EnableDoubleJump()
    {
        Debug.Log("Set Double Jump active");
        canDoubleJump = true;
    }
    public void EnableGrapplingHook()
    {
        Debug.Log("Set Grappling Hook active");
        canGrapple = true;
    }

    private void OnEnable()
    {
        PlayerLife.OnPlayerDeath += DisablePlayerMovement;
    }

    private void OnDisable()
    {
        PlayerLife.OnPlayerDeath -= DisablePlayerMovement;
    }

    private void DisablePlayerMovement()
    {
        //animator.enable = false;
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void EnablePlayerMovement()
    {
        //animator.enable = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
