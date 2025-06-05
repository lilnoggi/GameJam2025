using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator anim;

    private float xInput;
    private bool isGrounded;
    private bool isJumping;
    private bool isFalling;
    private bool lanternEquipped = false;
    private bool isInteracting = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleInput();
        HandleJump();
        HandleLanternToggle();
        UpdateStateFlags();
        UpdateAnimator();
    }

    void FixedUpdate()
    {
        CheckGround();
        Move();
    }

    void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);

        if (xInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(xInput), 1f, 1f);
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && Mathf.Abs(rb.linearVelocity.y) < 0.1f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void HandleLanternToggle()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
<<<<<<< Updated upstream
            float direction = Mathf.Sign(xInput);
            transform.localScale = new Vector3(direction, 1f, 1f);
        }
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void HandleLanternToggle()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (lanternEquipped)
            {
                anim.SetTrigger("UnequipLantern");
            }
            else
            {
                anim.SetTrigger("EquipLantern");
            }
        }
    }

    // Animation Events should call these
    public void OnEquipLanternComplete() => lanternEquipped = true;
    public void OnUnequipLanternComplete() => lanternEquipped = false;

    void UpdateStateFlags()
    {
        isJumping = rb.linearVelocity.y > 0.1f && !isGrounded;
        isFalling = rb.linearVelocity.y < -0.1f && !isGrounded;
    }

    void UpdateAnimator()
    {
        anim.SetFloat("Speed", Mathf.Abs(xInput));
        anim.SetBool("Grounded", isGrounded);
        anim.SetBool("IsWalking", Mathf.Abs(xInput) > 0.1f);
        anim.SetBool("LanternEquipped", lanternEquipped);
    }

        // Determine if walking
        bool isWalking = Mathf.Abs(xInput) > 0.1f;
        anim.SetBool("IsWalking", isWalking);

        // Jumping state logic (true if in the air)
        bool isJumping = !isGrounded;
        anim.SetBool("IsJumping", isJumping);

        Debug.Log($"Speed: {Mathf.Abs(xInput)}, Grounded: {isGrounded}, Interacting: {isInteracting}"); // Testing
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheckPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(groundCheckPoint.position, groundCheckSize);
        }
    }

    public void TriggerInteract()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isInteracting)
        {
            // Check for interactable object within range
            Collider2D target = Physics2D.OverlapCircle(interactPoint.position, interactRange, interactLayer);
            if (target != null && target.TryGetComponent(out IInteractable interactable))
=======
            if (lanternEquipped)
>>>>>>> Stashed changes
            {
                anim.SetTrigger("UnequipLantern");
            }
            else
            {
                anim.SetTrigger("EquipLantern");
            }
        }
    }

    // Animation Events should call these
    public void OnEquipLanternComplete() => lanternEquipped = true;
    public void OnUnequipLanternComplete() => lanternEquipped = false;

    void UpdateStateFlags()
    {
        isJumping = rb.linearVelocity.y > 0.1f && !isGrounded;
        isFalling = rb.linearVelocity.y < -0.1f && !isGrounded;
    }

    void UpdateAnimator()
    {
        anim.SetFloat("Speed", Mathf.Abs(xInput));
        anim.SetBool("Grounded", isGrounded);
        anim.SetBool("IsWalking", Mathf.Abs(xInput) > 0.1f);
        anim.SetBool("LanternEquipped", lanternEquipped);
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapBox(
            groundCheckPoint.position,
            groundCheckSize,
            0f,
            groundLayer
        );
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheckPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(groundCheckPoint.position, groundCheckSize);
        }
    }

    public void TriggerInteract()
    {
        anim.SetTrigger("Interact");
    }

    public void TriggerDeath()
    {
        anim.Play(lanternEquipped ? "Player_Death_Lantern" : "Player_Death");
    }

        public bool IsWalking => Mathf.Abs(xInput) > 0.1f;
}
