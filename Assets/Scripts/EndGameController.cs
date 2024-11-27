using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using Photon.Pun;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera; // Cámara principal
    [SerializeField] private GameObject endGameUI; // Letrero del final del juego
    [SerializeField] private float zoomOutSize = 15f; // Tamaño del zoom al mostrar al jefe
    [SerializeField] private float zoomOutDuration = 4f; // Duración de la animación de zoom

    private void OnEnable()
    {
        Flowermanager.HabilitadoParaGanar += StartEndGameSequence; // Subscribirse al evento
    }

    private void StartEndGameSequence()
    {
        StartCoroutine(ZoomOutCamera());
    }

    private IEnumerator ZoomOutCamera()
    {
        float initialSize = virtualCamera.m_Lens.OrthographicSize;
        float contador = 0f;

        while (contador < zoomOutDuration)
        {
            contador += Time.deltaTime;
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(initialSize, zoomOutSize, contador / zoomOutDuration);
            yield return null;
        }

        // Mostrar el letrero de final del juego
        endGameUI.SetActive(true);
    }

    public void EndGame() // Llamado desde un botón en el letrero
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect(); // Desconecta de Photon
        }

        PhotonNetwork.LoadLevel("inicio");
    }
}
