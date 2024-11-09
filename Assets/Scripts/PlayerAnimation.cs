using UnityEngine;
using Photon.Pun;

public class PlayerAnimation : MonoBehaviour, IPlayerObserver
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2D;
    private PhotonView photonView;
    private PlayerMove playerMove;
    private checkGround checkGroundd;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerMove.AddObserver(this);
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        photonView = GetComponent<PhotonView>();
        checkGroundd = GetComponentInChildren<checkGround>();
    }

    void Update()
    {
        if (checkGroundd.isGrounded)
        {
            animator.SetBool("jump", false);
        }
    }

    public void OnMove(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > 0.1f)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        spriteRenderer.flipX = direction.x > 0; // Gira el sprite si es necesario
    }

    public void OnJump()
    {
        animator.SetBool("jump", true);
        animator.SetBool("walk", false);
    }
}
