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
    int i;

    private float timebwattack;
    public float starttimebwattack;
    public Transform attackpos;
    public float attackrange;
    public LayerMask whatisenemy;

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
        if(timebwattack<=0)
        {
            if(Input.GetKeyDown(KeyCode.E) && isFacingRight)
            {
                Collider2D[] enemiestodamage = Physics2D.OverlapCircleAll(attackpos.position,attackrange,whatisenemy);
                Instantiate(slashright,new Vector2(transform.position.x+2, transform.position.y),Quaternion.identity);
                for(i=0;i<enemiestodamage.Length;i++)
                {
                    enemiestodamage[i].GetComponent<Enemy>().takedamage();
                }
            }
            else if(Input.GetKeyDown(KeyCode.E) && isFacingRight==false)
            {
                
                Collider2D[] enemiestodamage = Physics2D.OverlapCircleAll(attackpos.position,attackrange,whatisenemy);
                Instantiate(slashleft,new Vector2(transform.position.x-2, transform.position.y),Quaternion.identity);
                for(i=0;i<enemiestodamage.Length;i++)
                {
                    enemiestodamage[i].GetComponent<Enemy>().takedamage();
                
            }
            timebwattack = starttimebwattack;
            }
        }
        else{
            timebwattack -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpos.position,attackrange);
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
