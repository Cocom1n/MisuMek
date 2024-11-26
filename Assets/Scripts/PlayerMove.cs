using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviour
{
    private float runSpeed=200;
    private float jumpSpeed=350;
    private Rigidbody2D rb2D;
    private checkGround check;
    private List<IPlayerObserver> observers = new List<IPlayerObserver>();
    private PhotonView photonView;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        check = GetComponentInChildren<checkGround>();
        photonView = GetComponent<PhotonView>();
    }

    public void AddObserver(IPlayerObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IPlayerObserver observer)
    {
        observers.Remove(observer);
    }

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            Vector2 direction = Vector2.zero;

            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                direction = Vector2.right;
            }
            else if (Input.GetKey("a") || Input.GetKey("left"))
            {
                direction = Vector2.left;
            }

            // Aplica la velocidad solo si hay dirección
            rb2D.velocity = new Vector2(direction.x * runSpeed * Time.deltaTime, rb2D.velocity.y);
            NotifyMove(direction);

            if (Input.GetKey("space") && check.isGrounded)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed * Time.deltaTime);
                NotifyJump();
            }
        }
    }


    //Logica Observer

    private void NotifyMove(Vector2 direction)
    {
        foreach (var observer in observers)
        {
            observer.OnMove(direction);
        }

    }

    private void NotifyJump()
    {
        foreach (var observer in observers)
        {
            observer.OnJump(); 
        }
    }
}
