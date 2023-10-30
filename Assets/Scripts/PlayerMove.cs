using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed=2;    //velocidad de movimiento del personaje
    public float jumpSpeed=3;   //Velocidad de salto
    Rigidbody2D rb2D;   //referencia al Rb2D del personaje

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed * Time.deltaTime , rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("walk", true);
        }
        
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed * Time.deltaTime, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("walk", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("walk", false);
        }
        if(Input.GetKey("space") && checkGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed * Time.deltaTime);
        }

        if(checkGround.isGrounded==false)
        {   
            animator.SetBool("jump", true);
            animator.SetBool("walk", false);
        }
        if(checkGround.isGrounded==true)
        {   
            animator.SetBool("jump", false);
        }
    }
}
