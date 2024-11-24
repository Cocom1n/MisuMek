using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMove : MonoBehaviour
{
    public float velocity = 150;
    private EnemyPool enemyPool; // Referencia al Enemy Pool

    void Start()
    {
        enemyPool = FindObjectOfType<EnemyPool>();

        if (enemyPool == null)
        {
            Debug.LogError("No se encontró el Enemy Pool en la escena.");
        }
    }

    void Update()
    {
        // Mueve el objeto en el eje Y hacia abajo
        transform.position += -transform.up * Time.deltaTime * velocity;
        if (transform.position.y < -10)
        {
            enemyPool.ReturnEnemy(gameObject);
        }
    }
}

