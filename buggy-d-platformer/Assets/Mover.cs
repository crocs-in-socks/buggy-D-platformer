using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public bool FacingRight = true;
    private bool IsGrounded;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public GameObject slashleft;
    public GameObject slashright;

    private int extraJumps;
    public int extraJumpValue;

    void Start()
    {
        extraJumps = extraJumpValue;
    }

    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(FacingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(FacingRight == true && moveInput < 0)
        {
            Flip();
        }

    }

    void Update()
    {
        if(IsGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        if(Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && IsGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        
        if(Input.GetKeyDown(KeyCode.E) && FacingRight==true)
        {
            Instantiate(slashright,new Vector2(transform.position.x+2, transform.position.y),Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.E) && FacingRight==false)
        {
            Instantiate(slashleft,new Vector2(transform.position.x-2, transform.position.y),Quaternion.identity);
            
        }
    }
    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1f;
        transform.localScale = Scaler;
    }
}

