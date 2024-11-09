using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class checkGround : MonoBehaviour
{
    //Script que se encarga de verificar si el jugador esta colicionando con las plataformas
    
    public bool isGrounded; //Static significa que la variable puede ser usada en otros scripts
    private PhotonView photonView;
    
    void Start()
    {
        photonView = GetComponentInParent<PhotonView>(); // Accedemos al PhotonView del Player.
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (photonView != null && photonView.IsMine) // Solo el jugador local actualiza su estado.
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (photonView != null && photonView.IsMine) // Solo el jugador local actualiza su estado.
        {
            isGrounded = false;
        }
    }
}
