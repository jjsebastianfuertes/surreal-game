using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public Player vidaJugador;
    public GameObject enemigo;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    void Start() {

        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    void Spawn() {
        Debug.Log("sapwneando");
        if (vidaJugador.health <= 0f) {
            return;
        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemigo, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}

