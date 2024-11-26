using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Flowermanager : MonoBehaviour
{
    private bool tieneTodasLasFlores = false;
    public static event Action HabilitadoParaGanar;

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
            HabilitadoParaGanar?.Invoke();
            Debug.Log("Habilitado para ganar");
        }
        else
        {
            Debug.Log("Faltan flores para poder ganar");
        }
    }
}
