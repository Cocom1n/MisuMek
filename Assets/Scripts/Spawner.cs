using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemigos; //referencia al prefab del enemigo

    public float intervalo = 0.5f; //intervalo de tiempo para spawnear cada enemigo

    public float repeatSpawnRate = 3;

    //variables que reprecentan el area de spawn para los enemigos
    public Transform minX;
    public Transform maxX;
    public Transform minY;
    public Transform maxY;


    void Start()
    {
        InvokeRepeating("SpawnEnemigos", intervalo, repeatSpawnRate);
    }

    public void SpawnEnemigos()
    {
        Vector3 spawnpPos = new Vector3(0, 0, 0);
        spawnpPos = new Vector3(Random.Range(minX.position.x,maxX.position.x), Random.Range(minY.position.y,maxY.position.y), 0);
        GameObject enemigo = Instantiate (enemigos,spawnpPos,gameObject.transform.rotation);
    }

}
