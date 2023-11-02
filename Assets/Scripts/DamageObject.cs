using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detecta la colicion de cualquier enemigo con el jugador
        if (collision.transform.CompareTag("Player"))
        {
            //llama a al metodo dentro del script del jugador para restar vidas
            collision.transform.GetComponent<VidasManager>().restarVida();
        }
    }
}
