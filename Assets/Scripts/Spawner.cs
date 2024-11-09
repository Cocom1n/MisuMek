using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyPool enemyPool; 
    private float tiempoInicial = 0.05f;
    [SerializeField] private float intervalo;

    public Transform minX;
    public Transform maxX;
    public Transform minY;
    public Transform maxY;

    void Start()
    {
        InvokeRepeating("SpawnEnemigos", tiempoInicial, intervalo);
    }

    public void SpawnEnemigos()
    {
        Vector3 spawnPos = new Vector3(Random.Range(minX.position.x, maxX.position.x), Random.Range(minY.position.y, maxY.position.y), 0);

        GameObject enemigo = enemyPool.GetEnemy();
        enemigo.transform.position = spawnPos;
    }
}

