using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    Rigidbody2D rb;
    Animator anim;

    public float maxSpeed;
    public float jumpHeight;

    public Joystick joystick;

    bool facingRight;
    bool grounded = false;
    float move = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = true;
    }

    void FixedUpdate()
    {
        Controller();
        Animation();
    }

    void Controller()
    {
        if (joystick.Horizontal >= .2f)
        {
            move = maxSpeed;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            move = -maxSpeed;
        }
        else
        {
            move = 0f;
        }
        float verticalMove = joystick.Vertical;

        anim.SetFloat("speed", Mathf.Abs(move));

        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        if (verticalMove >= .6f)
        {
            if (grounded)
            {
                grounded = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                
            }
        }

    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }

    }

    void Animation()
    {
        if (grounded == false)
        {
            anim.SetBool("jumping", true);
        }
        if (grounded == true)
        {
            anim.SetBool("jumping", false);
        }
    }
}
