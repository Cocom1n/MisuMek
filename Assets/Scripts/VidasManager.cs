using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidasManager : MonoBehaviour
{
    //Script que se encarga de restar vidas y desactivar su imagen en el Canvas

    private int cantVidas = 3;
    public GameObject[] imgVida; //arreglo donde se agregan las imagenes de las vidas dentro del canvas

    public void restarVida ()
    {
        cantVidas -=1; //resta una vida cada vez que el metodo es llamado por el DamageObject
        imgVida[cantVidas].SetActive(false);  //Desactiva del canvas la imagen correspondiente a la vida perdida
        if (cantVidas==0) //cuando la cantidad de vidas sea 0 va a invocar el cambio de escena y desactivar la vista del player
        {
            Invoke("cambiarEscena", 1);  
            gameObject.SetActive(false);
        }
    }

    public void cambiarEscena()
    {
        SceneManager.LoadScene("lose");
    }
}
