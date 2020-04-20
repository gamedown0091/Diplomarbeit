using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

   
    public float maxSpeed = 10f;
    public float jumpForce = 350f;
    bool grounded = false;
    public Transform groundCheck;
    private bool faceingRight = true;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public Vector2 respawnpoint;
    private bool activePlayer;
	// Use this for initialization
	void Start () {
        respawnpoint = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        float move = Input.GetAxis("Horizontal");
        if (activePlayer)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (move > 0 && !faceingRight)
            Flip();
        else if (move < 0 && faceingRight)
            Flip();
	}

    void Update()
    {
        if (activePlayer)
        {
            if (grounded && Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            }
        }
    }

    void Flip()
    {
        faceingRight = !faceingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

    public void setActivePlayer(bool active)
    {
        this.activePlayer = active;
    }

    public bool getActivePlayer()
    {
        return activePlayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Falldetector")
        {
            transform.position = respawnpoint;
        }
    }
}
