using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    public Transform pointA; // El objeto Empty para el punto A
    public Transform pointB; // El objeto Empty para el punto B
    public float movementSpeed = 5f; // Velocidad de movimiento del enemigo

    private bool movingToA = true; // Indica si el enemigo se está moviendo hacia A o B

    void Start()
    {
        StartCoroutine(MoveBetweenPoints());
    }

    IEnumerator MoveBetweenPoints()
    {
        while (true)
        {
            Vector3 targetPosition = movingToA ? pointA.position : pointB.position;
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
                yield return null;
            }
            movingToA = !movingToA;
            yield return new WaitForSeconds(1.0f); // Espera un segundo antes de cambiar de dirección
        }
    }
}
