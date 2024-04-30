using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    private enum MovementState {  idle, runningUp, runningDown, run }

    public float dirX = 0f;
    public float dirY = 0f;

    [SerializeField] private float Speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
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
            coll.enabled = false;
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

        if (dirY > 0.1f)
        {
            state = MovementState.runningUp;
        }
        else if (dirY < -0.1f)
        {
            state = MovementState.runningDown;
        }

        if (dirX > 0.1f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }
        else if (dirX < -0.1f)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }

        else
        {
            state = MovementState.idle;
        }

        anim.SetInteger("state", (int)state);
    }

    IEnumerator endTunnel()
    {
        coll.enabled = true;
        yield return new WaitForSeconds(0.5f);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
