using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D coll;
    public SpriteRenderer sprite;
    public Animator anim;

    [SerializeField] public LayerMask jumpableGround;

    public float dirX = 0f;
    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] public float jumpForce = 1f;
    public int jumpsRemaining = 0; // Track the number of jumps allowed

    public enum MovementState { idle, running, jumping, falling }

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && (IsGrounded() || jumpsRemaining > 0))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
            jumpsRemaining--;

            if (jumpsRemaining == 0)
            {
                // Disable further jumps until grounded again
                jumpsRemaining = -1;
            }
        }

        if (IsGrounded())
        {
            jumpsRemaining = 2; // Reset jumps when grounded
        }

        UpdateAnimationState();
    }

    public void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}