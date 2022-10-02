using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public GameObject slashleft;
    public GameObject slashright;
    int i;

    private float timebwattack;
    public float starttimebwattack;
    public Transform attackpos;
    public float attackrange;
    public LayerMask whatisenemy;

    public Rigidbody2D rb;
    public AudioSource audio;

    // For Animations
    private Animator anime_man;

    //Movement Variables
    public float speed;
    private float moveInput;
    public float jumpForce;
    private bool isFacingRight = true;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start()
    {
        anime_man = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(isFacingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(isFacingRight == true && moveInput < 0)
        {
            Flip();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    void Update()
    {
        if(isGrounded == true && Input.GetKey(KeyCode.Space))
        {
            anime_man.SetTrigger("TakeOff");
            rb.velocity = Vector2.up * jumpForce;
            FindObjectOfType<AudioManager>().Play("Jumping");
        }

        if(isGrounded == false)
        {
            anime_man.SetBool("IsJumping", true);
        }
        else
        {
            anime_man.SetBool("IsJumping", false);
        }

        if(moveInput == 0)
        {
            anime_man.SetBool("IsRunning", false);
        }
        else
        {
            anime_man.SetBool("IsRunning", true);
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
                anime_man.SetTrigger("RSlash");
                FindObjectOfType<AudioManager>().Play("Slash");
            }
            else if(Input.GetKeyDown(KeyCode.E) && isFacingRight==false)
            {
                
                Collider2D[] enemiestodamage = Physics2D.OverlapCircleAll(attackpos.position,attackrange,whatisenemy);
                Instantiate(slashleft,new Vector2(transform.position.x-2, transform.position.y),Quaternion.identity);
                for(i=0;i<enemiestodamage.Length;i++)
                {
                    enemiestodamage[i].GetComponent<Enemy>().takedamage();
                }
                anime_man.SetTrigger("RSlash");
                FindObjectOfType<AudioManager>().Play("Slash");
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

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1f;
        transform.localScale = Scaler;
        Debug.Log("Flipped");
    }

    void Footsteps()
    {
        if(moveInput != 0 && isGrounded == true)
        {
            if(audio.isPlaying == false)
            {
                audio.Play();
            }
            else
            {
                audio.Stop();
            }
        }
    }
}
