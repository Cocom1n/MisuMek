using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private int poolSize = 10;
    private Queue<GameObject> pool;

    void Start()
    {
        pool = new Queue<GameObject>();

        // Inicializamos el pool creando objetos enemigos
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemigo = Instantiate(enemigoPrefab);
            enemigo.SetActive(false); // Los enemigos no están activos al inicio
            pool.Enqueue(enemigo);
        }
    }

    public GameObject GetEnemy()
    {
        if (pool.Count > 0)
        {
            GameObject enemigo = pool.Dequeue();
            enemigo.SetActive(true); // Activamos el enemigo
            return enemigo;
        }
        else
        {
            // Si el pool está vacío, podemos crear un nuevo enemigo si es necesario
            GameObject enemigo = Instantiate(enemigoPrefab);
            return enemigo;
        }
    }

    // Devolver un enemigo al pool
    public void ReturnEnemy(GameObject enemigo)
    {
        enemigo.SetActive(false); // Desactivamos el enemigo antes de devolverlo
        pool.Enqueue(enemigo);
    }
}
