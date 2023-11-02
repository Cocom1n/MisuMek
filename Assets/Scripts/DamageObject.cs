using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    
    //[SerializeField] private VidasManager vidas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //vidas.restarVida();
            Debug.Log("gato kill");
            //Destroy(gameObject);
        }
    }
}
