using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal;
    public float sideSpeed = 8f;
    public float jumpSpeed = 16f;
    public bool isFacingRight = true;
    public GameObject slashleft;
    public GameObject slashright;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if(Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if(Input.GetKeyDown(KeyCode.E) && isFacingRight)
        {
            Instantiate(slashright,new Vector2(transform.position.x+2, transform.position.y),Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.E) && isFacingRight==false)
        {
            Instantiate(slashleft,new Vector2(transform.position.x-2, transform.position.y),Quaternion.identity);
            
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * sideSpeed, rb.velocity.y);
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Flip()
    {
        if(isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
