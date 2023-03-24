using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    public GameObject deathScreen;

    public PlayerHealth playerHealth;
    private Vector3 startPosition;
    
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 2f;
        jumpForce = 9F;
        isJumping = false;

        startPosition = transform.position;
    }

    
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");


    }

    void FixedUpdate()
    {
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (!isJumping && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
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
