using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public Transform[] spawnLocations;
    public float spawnTime;
    public GameObject cyberSoldierPrefab;
 

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    public void Spawn()
    {
        Transform spawn = spawnLocations[Random.Range(0, spawnLocations.Length)];
        GameObject cyberSoldier = Instantiate(cyberSoldierPrefab, spawn.position, spawn.rotation);
    }
    
}
