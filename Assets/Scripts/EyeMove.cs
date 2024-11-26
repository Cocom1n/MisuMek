using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMove : MonoBehaviour
{
    private float velocity = 5;// Referencia al Enemy Pool

    void Update()
    {
        // Mueve el objeto en el eje Y hacia abajo
        transform.position += -transform.up * Time.deltaTime * velocity;

    }
}

