using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject enemigos; //referencia al prefab del enemigo

    private float tiempoInicial = 0.05f; //tiempo de espera inicial para invocar al primer enemigo
    [SerializeField] private float intervalo; //intervalo de tiempo para spawnear cada enemigo

    //variables que reprecentan el area de spawn para los enemigos
    public Transform minX;
    public Transform maxX;
    public Transform minY;
    public Transform maxY;


    void Start()
    {
        InvokeRepeating("SpawnEnemigos", tiempoInicial, intervalo); //Se encarga de invocar a los enemigos en un intervalo de tiempo despues del tiempo inicial
    }

    public void SpawnEnemigos()
    {
        Vector3 spawnpPos = new Vector3(0, 0, 0);
        //determina un valor aleatorio entre los puntos establecidos para hacerlo el punto de spawn
        spawnpPos = new Vector3(Random.Range(minX.position.x,maxX.position.x), Random.Range(minY.position.y,maxY.position.y), 0);
        GameObject enemigo = Instantiate (enemigos,spawnpPos,gameObject.transform.rotation); //instancia al enemigo en el pocicion dada anteriormente
    }

}
