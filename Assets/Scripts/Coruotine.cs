using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coruotine : MonoBehaviour
{
    /* Las corrutinas son funciones especiales que pueden suspenderse y reanudarse en diferentes fotogramas (frames) del juego.
Son útiles para realizar tareas que necesitan tiempo, como esperar un período antes de continuar, crear efectos o animaciones, o ejecutar tareas en segundo plano.
Las corrutinas se inician con el uso de StartCoroutine() y pueden incluir declaraciones yield, que especifican cuándo pausar y reanudar la rutina. */

    void Start()
    {
        StartCoroutine("MiCorrutina");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hola");
    }

    IEnumerator MiCorrutina(){
        Debug.Log("Hola");
        yield return new WaitForSeconds(1);
        Debug.Log("Buenos Dias");
        yield return new WaitForSeconds(3);
        Debug.Log("Hasta Luego");
        yield return new WaitForSeconds(1);
        StartCoroutine("MiCorrutina");
    }



}

/* Ejercicio: Mofificar el ejercicio anterior para pasar por parametro el tiempo (float) Ej 2.


 */