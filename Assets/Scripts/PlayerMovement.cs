using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float moveSpeed = 8f;
    private float jumpPower = 16f;
    private bool isJumping;
    private bool isFacingRight = true;
    private float moveHorizontal;
    private float moveVertical;
    public GameObject deathScreen;

    public PlayerHealth playerHealth;
    private Vector3 startPosition;
    
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        
        isJumping = false;

        startPosition = transform.position;
    }

    
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpPower);
        }

        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0f)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }

        Flip();
    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(moveHorizontal * moveSpeed, rb2D.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && moveHorizontal < 0f || !isFacingRight && moveHorizontal > 0f)
        {
            isFacingRight = isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {


        if(collision.gameObject.tag == "Death")
        {


            playerHealth.playerHealth--;
            playerHealth.UpdateHealth();

            if (playerHealth.playerHealth <=0)
            {
                deathScreen.SetActive(true);
                rb2D.bodyType = RigidbodyType2D.Static;

            } else
            {
                //playerHealth.playerHealth = 11; ;
                //playerHealth.UpdateHealth();
                transform.position = startPosition;
                //respawn
            }



            ///
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isJumping = true;
        }
    }

    
   
}
