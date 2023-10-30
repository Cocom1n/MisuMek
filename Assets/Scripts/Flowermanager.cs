using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowermanager : MonoBehaviour
{

    //metodo que pregunta si todas las flores fueron recolectadas
    public void AllFlowersCollected()
    {
        if(transform.childCount==1)
        {
            Debug.Log("Todas las flores fueron recollectadas");
        }
    }
}
