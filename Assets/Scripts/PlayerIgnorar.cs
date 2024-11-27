using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerIgnorar : MonoBehaviour
{

    public MonoBehaviour[] codigosIgnorar;
    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if(!photonView.IsMine)
        {
            foreach(var codigo in codigosIgnorar)
            {
                codigo.enabled=false;
            }
        }
    }
}
