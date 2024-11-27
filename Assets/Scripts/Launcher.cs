// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Photon.Pun;
// using Cinemachine;

// public class Launcher : MonoBehaviourPunCallbacks
// {
//     public PhotonView playerPrefab;
//     public Transform spawn;
//     private CinemachineVirtualCamera virtualCamera;

//     void Start()
//     {
//         PhotonNetwork.ConnectUsingSettings(); 
//         virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
//     }

//     public override void OnConnectedToMaster()
//     {
//         PhotonNetwork.JoinRandomOrCreateRoom();
//     }

//     public override void OnJoinedRoom()
//     {
//         PhotonNetwork.Instantiate(playerPrefab.name, spawn.position, spawn.rotation);

//         if (playerPrefab.GetComponent<PhotonView>().IsMine && virtualCamera != null)
//         {
//             virtualCamera.Follow = playerPrefab.transform;
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;  
    public Transform spawn;
    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawn.position, spawn.rotation);

        if (player.GetComponent<PhotonView>().IsMine)
        {
            // Inicia una corrutina para asignar el follow de la cámara
            StartCoroutine(AssignCameraFollow(player.transform));
        }
    }

    private IEnumerator AssignCameraFollow(Transform playerTransform)
    {
        // Espera hasta que la cámara esté completamente lista
        while (virtualCamera == null)
        {
            virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
            yield return null;
        }

        // Asigna el jugador al Follow de la cámara
        virtualCamera.Follow = playerTransform;
    }
}

