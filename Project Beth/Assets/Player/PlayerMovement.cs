using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private float doubleJumpingPower = 10f;
    public bool isFacingRight { get; private set; } = true;

    private bool doubleJump;
    private bool canDoubleJump = false;

    public bool isGrappling { get; set; } = false;
    private bool canGrapple = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;

    public PlayerInventory inventory;

    private void Start()
    {
        EnablePlayerMovement();
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
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

        Flip();
        
    }

    public void UseGrapplingHook(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded() && canGrapple)
        {
            inventory.UseAbility<Grapple>();
        }
    }

    public void LaunchGrapplingHook(GameObject hookPrefab, float hookSpeed, float pullSpeed)
    {
        if (!isGrappling)
        {
            GameObject hook = Instantiate(hookPrefab, transform.position, Quaternion.identity);
            hook.GetComponent<GrapplingHook>().Initialize(this, hookSpeed, pullSpeed);
            isGrappling = true;
        }
    }

    public IEnumerator PullToPosition(Vector3 targetPosition, float speed)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        isGrappling = false;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);
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
