using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flowermanager : MonoBehaviour
{
    private bool tieneTodasLasFlores = false;
    
    //metodo que pregunta si todas las flores fueron recolectadas
    public void AllFlowersCollected()
    {
        if(transform.childCount==1)
        {
            tieneTodasLasFlores = true;
        }
    }

    //Si el jugador llego a la cima y tiene todas las flores ganara
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(tieneTodasLasFlores)
        {
            SceneManager.LoadScene("win");
        }
        else
        {
            Debug.Log("Faltan flores para poder ganar");
        }
    }
}
