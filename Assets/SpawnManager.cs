using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Referencias a los prefabs que queremos spawnear
    public GameObject objectToSpawn1;
    public GameObject objectToSpawn2;

    // Rango de posiciones para el spawn
    public Vector3 spawnRangeX;
    public Vector3 spawnRangeY;

    // Start se llama antes del primer frame update
    void Start()
    {
        // Llamamos a la función para spawnear los objetos al iniciar el juego
        InvokeRepeating("SpawnObjects", 1, 3);
    }

    void SpawnObjects()
    {
        // Generamos una posición aleatoria para el primer objeto
        Vector3 randomPosition1 = new Vector3(
            Random.Range(spawnRangeX.x, -spawnRangeX.x),2,
            Random.Range(spawnRangeY.z, spawnRangeY.z)
        );

        // Generamos una posición aleatoria para el segundo objeto
        Vector2 randomPosition2 = new Vector3(
            Random.Range(spawnRangeX.x, -spawnRangeX.x), 2,
            Random.Range(spawnRangeY.z, -spawnRangeY.z)
        );

        // Instanciamos los objetos en las posiciones aleatorias
        Instantiate(objectToSpawn1, randomPosition1, Quaternion.identity);
        Instantiate(objectToSpawn2, randomPosition2, Quaternion.identity);
    }
}

