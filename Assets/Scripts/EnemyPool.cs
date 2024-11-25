using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private int poolSize = 10;
    private Queue<GameObject> pool = new Queue<GameObject>();
    public static EnemyPool Instance { get; private set; }

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
            enemigo.SetActive(true);
            return enemigo;
        }
        else
        {
            return null;
        }
    }

    // Devolver un enemigo al pool
    public void ReturnEnemy(GameObject enemigo)
    {
        enemigo.SetActive(false);
        pool.Enqueue(enemigo);
    }
}
