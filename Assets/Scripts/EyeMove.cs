using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMove : MonoBehaviour
{

    public float velocity = 150;

    void Start()
    {
        //destruye el objeto despues de 10 segundos
        Destroy(gameObject, 10); 
    }

    void Update()
    {
        //mueve el objeto en el eje Y hacia abajo
        transform.position += -transform.up * Time.deltaTime * velocity;
    }
}
