using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float runSpeed=2;    //velocidad de movimiento del personaje
    [SerializeField] public float jumpSpeed=3;   //Velocidad de salto
    Rigidbody2D rb2D;   //referencia al Rb2D del personaje

    //referencias a componentes del objeto para realizar las animaciones del personaje
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Movimiento hacia la derecha
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed * Time.deltaTime , rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("walk", true); //Establece que la animacion que se reproducira cuando se ejecute este movimiento
        }
        
        //Movimiento hacia la izquierda
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed * Time.deltaTime, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("walk", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("walk", false); //si walk o jump son falsas el personaje se mostrara en un estado idle
        }

        //salto
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
