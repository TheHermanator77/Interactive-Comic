using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCopy : MonoBehaviour
{
    // Used in overall movement
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    private float dirX = 0f;
    private float dirY = 0f;

    [SerializeField] private float Speed = 7f;

    // Used in Tunneling
    private bool canTunnel;
    //private float startTime = 0f;
    // private float timeHeld;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * Speed, rb.velocity.y);

        dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, dirY * Speed);

        // Allows Tunneling Right
        if (Input.GetKeyDown(KeyCode.Space) && canTunnel == true && dirX > 0.1f)
        {
            Debug.Log("Space Was Pressed Facing Right");
            transform.position = new Vector3(transform.position.x + 2.0f, transform.position.y, transform.position.z);
        }

        // Allows Tunneling Left
        if (Input.GetKeyDown(KeyCode.Space) && canTunnel == true && dirX < 0f)
        {
            Debug.Log("Space Was Pressed Facing Left");
            transform.position = new Vector3(transform.position.x - 2.0f, transform.position.y, transform.position.z);
        }

        // Allows Tunneling Up
        if (Input.GetKeyDown(KeyCode.Space) && canTunnel == true && dirY > 0.1f)
        {
            Debug.Log("Space Was Pressed Facing Up");
            transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        }

        // Allows Tunneling Down
        if (Input.GetKeyDown(KeyCode.Space) && canTunnel == true && dirY < 0f)
        {
            Debug.Log("Space Was Pressed Facing Down");
            transform.position = new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z);
        }
    }

    // When contact with a wall is detected, canTunnel = true.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            Debug.Log("Can Tunnel");
            canTunnel = true;
        }
    }

    // When there is no longer contact with a wall, canTunnel = false.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            Debug.Log("Can't Tunnel!!");
            canTunnel = false;
        }
    }
}
