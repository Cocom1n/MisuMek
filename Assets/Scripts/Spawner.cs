using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, ISwitcheable
{
    private float tiempoInicial = 0.05f;
    [SerializeField] private float intervalo;

    public Transform minX;
    public Transform maxX;
    public Transform minY;
    public Transform maxY;

    private bool isActive = false;
    private bool isDirty = false;
    private bool isSpawning = false;

    private BoxCollider2D ZonaSpawn;

    private List<GameObject> enemigosActivos = new List<GameObject>();

    void Start()
    {
        ZonaSpawn = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isDirty)
        {
            if (isActive && !isSpawning)
            {
                isSpawning = true;
                InvokeRepeating("SpawnEnemigos", tiempoInicial, intervalo);
            }
            else if (!isActive && isSpawning)
            {
                isSpawning = false;
                CancelInvoke("SpawnEnemigos");
            }
            isDirty = false;
        }

        for (int i = enemigosActivos.Count - 1; i >= 0; i--)
        {
            GameObject enemigo = enemigosActivos[i];
            if (enemigo.transform.position.y < maxY.position.y-30 )
            {
                // Devuelve el enemigo al pool y lo elimina de la lista
                EnemyPool.Instance.ReturnEnemy(enemigo);
                enemigosActivos.RemoveAt(i);
            }
        }
    }

    public void SetActive(bool isActive)
    {
        if (this.isActive != isActive) // Sólo actualizamos si el estado cambió
        {
            this.isActive = isActive;
            isDirty = true; // Marcamos el estado como "sucio"
        }
    }

    public bool IsActive()
    {
        return isActive;
    }
    public void SpawnEnemigos()
    {
        Vector3 spawnPos = new Vector3(Random.Range(minX.position.x, maxX.position.x), Random.Range(minY.position.y, maxY.position.y), 0);

        GameObject enemigo = EnemyPool.Instance.GetEnemy();
        if (enemigo != null) // Si hay enemigos disponibles en el pool
        {
            enemigo.transform.position = spawnPos;
            enemigo.SetActive(true); // Activa el enemigo del pool
            enemigosActivos.Add(enemigo);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetActive(false);
        }
    }
}

