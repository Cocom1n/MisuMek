using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB; 

    public float speed = 5f; 

    private bool movingToA = true; 

    void Start()
    {
        StartCoroutine(patrullaje());
    }

    IEnumerator patrullaje()
    {
        while (true) // mantiene la siguiente accion en un loop infinito

        {   //pregunta si se esta moviendo hacia el punto A, si es verdadero se va a mover al punto A, si es falso se va a mover al punto B y lo asigna en targetPosition
            Vector3 targetPosition = movingToA ? pointA.position : pointB.position;
            while (transform.position != targetPosition) //mientras que la poscicion actual sea distinta al target se va a mover hacia este para luego cambiar de direccion
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }
            movingToA = !movingToA; //invierte la variable para cambiar el targetPosition
            yield return new WaitForSeconds(1.0f);
        }
    }
}
