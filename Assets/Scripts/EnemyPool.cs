using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private int poolSize = 10;
    private Queue<GameObject> pool = new Queue<GameObject>();
    public static EnemyPool Instance { get; private set; }

    //void Start()
    //{

    //    //Crea a todos los enemigos
    //    for (int i = 0; i < poolSize; i++)
    //    {
    //        GameObject enemigo = Instantiate(enemigoPrefab);
    //        enemigo.SetActive(false);
    //        pool.Enqueue(enemigo);
    //    }
    //}
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemigoPrefab);
            enemy.SetActive(false);
            pool.Enqueue(enemy);
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
            //GameObject enemigo = Instantiate(enemigoPrefab);
            //return enemigo;
            return null;
        }
    }

    // Devolver un enemigo al pool
    public void ReturnEnemy(GameObject enemigo)
    {
        enemigo.SetActive(false); // Desactivamos el enemigo antes de devolverlo
        pool.Enqueue(enemigo);
    }
}
