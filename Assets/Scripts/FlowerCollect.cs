using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FlowerCollect : MonoBehaviour
{
    private float puntoFlor = 1;
    [SerializeField] private AudioSource collect;
    [SerializeField] private Score score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //si un objeto con el tag de player coliciona con el objeto actual (la flor) realizara
        //la animacion, repoducira un sonido y destruira el objeto
        if(collision.CompareTag("Player"))
        {
            collect.Play(); //sonido al recolectar una flor

            score.SumarPunto(puntoFlor); //Llama al script que suma los puntos para sumar un putno cada vez que recolecta una flor

            GetComponent<SpriteRenderer>().enabled = false; //desactiva el sprite de la flor para que se vea la siguiente animacion
            gameObject.transform.GetChild(0).gameObject.SetActive(true); //activa el hijo dentro de la flor que reprecenta la animacion de collected

            FindObjectOfType<Flowermanager>().AllFlowersCollected();// llama al FloerManager para preguntar si todas las flores fueron recolectadas y asi pasar de nivel
            Destroy(gameObject, 0.5f);//destruye el objeto luego de 0.5 de tiempo
        }
    }

}
