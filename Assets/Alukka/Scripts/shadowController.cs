using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;

    public float DirX = 0f;
    public float DirY = 0f;

    [SerializeField] private float Speed = 7f;
    [SerializeField] private GameObject Player;

    private bool isFollowing = true;
    private bool canTunnel = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DirX = Input.GetAxisRaw("Horizontal");
        DirY = Input.GetAxisRaw("Vertical");

        if (isFollowing == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            sprite.enabled = false;
            coll.enabled = false;
            transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y);
        }
        if (isFollowing == false)
        {
            sprite.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && DirX > 0f) // Tunneling facing right
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            isFollowing = false;
            rb.velocity = new Vector2(DirX * Speed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && DirX < 0f) // Tunneling facing left
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            isFollowing = false;
            rb.velocity = new Vector2(DirX * Speed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && DirY > 0f) // Tunneling facing up
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            isFollowing = false;
            rb.velocity = new Vector2(rb.velocity.x, DirY * Speed);
        }

        if ( Input.GetKeyDown(KeyCode.Space) && DirY < 0f) // Tunneling facing down
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            isFollowing = false;
            rb.velocity = new Vector2(rb.velocity.x, DirY * Speed);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(Tunneling());
        }
    }

    IEnumerator Tunneling()
    {
        yield return

        coll.enabled = true;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;

        yield return new WaitForSeconds(0.5f);

        if (canTunnel == true)
        {
            Player.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        if (canTunnel == false)
        {
            transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y);
        }

        coll.enabled = false;
        isFollowing = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            canTunnel = false;
            isFollowing = true;
            Debug.Log("Wall Collision");
        }
    }
}
