using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class DefeatControler : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject defeatPanel;
    [SerializeField] private PlayerMove playerMove;
    private Vida vidas;
    [SerializeField] private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        //photonView = GetComponent<PhotonView>();

        if (photonView.IsMine)
        {
            vidas = GetComponent<Vida>();
            //playerMove = GetComponent<PlayerMove>();
            vidas.JugadorDerrotado += HandleDefeat;
        }
    }

    private void HandleDefeat()
    {
        playerMove.enabled = false; // Desactivar el movimiento del jugador
        defeatPanel.SetActive(true); // Mostrar el panel de derrota
    }

    public void RestartGame()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect(); // Desconecta de Photon
        }
        
        PhotonNetwork.LoadLevel("inicio"); 
    }

}
