using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;

    private enum MovementState {  idle, runningUp, runningDown }

    private float dirX = 0f;
    private float dirY = 0f;

    [SerializeField] private float Speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gives function to input system
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * Speed, rb.velocity.y);

        dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, dirY * Speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(endTunnel());
        }

        UpdateAnimationState(); // Changes the animation
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        // Determines which animation plays when

        if (dirY > 0f)
        {
            state = MovementState.runningUp;
        }
        else if (dirY < 0f)
        {
            state = MovementState.runningDown;
        }
        else
        {
            state = MovementState.idle;
        }

        anim.SetInteger("state", (int)state);
    }

    IEnumerator endTunnel()
    {
        yield return new WaitForSeconds(0.5f);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
