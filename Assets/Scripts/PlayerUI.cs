using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerUI : MonoBehaviour
{
    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponentInParent<PhotonView>(); // Obtiene el PhotonView del jugador
        Canvas canvas = GetComponent<Canvas>();

        if (!photonView.IsMine)
        {
            // Si no es el jugador local, desactiva el Canvas
            canvas.enabled = false;
        }
    }
}
