using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DamageObject : MonoBehaviour
{
    [SerializeField] private AudioSource golpe;
    [SerializeField] private Vida vidas;

    void Start()
    {
        //vidas = GetComponentInChildren<Vida>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detecta la colicion de cualquier enemigo con el jugador
        if (collision.transform.CompareTag("Player"))
        {
            //llama a al metodo dentro del script del jugador para restar vidas
            vidas = collision.GetComponentInChildren<Vida>();
            golpe.Play();
            vidas.RestarVida();
            Debug.Log("toma esto gato malo");

            //collision.transform.GetComponent<VidasManager>().restarVida();
        }
    }
}
