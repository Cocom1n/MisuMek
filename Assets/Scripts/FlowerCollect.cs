using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCollect : MonoBehaviour
{
     private float puntoFlor = 1;
    [SerializeField] private Score score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //si un objeto con el tag de jugador coliciona con el objeto actual (la flor) realizara
        //la animacion y destruira el objeto
        if(collision.CompareTag("Player"))
        {
            score.SumarPunto(puntoFlor);
            GetComponent<SpriteRenderer>().enabled = false;
            //activa el hijo dentro de la flor que reprecenta la animacion de collected
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            FindObjectOfType<Flowermanager>().AllFlowersCollected();
            Debug.Log("Flor agarrada");
            //destruye el objeto luego de 0.5 de tiempo
            Destroy(gameObject, 0.5f);
        }
    }

}
