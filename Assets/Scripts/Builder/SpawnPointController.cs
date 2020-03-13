using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour {
    public static WaveSpawner[] spawnPoints;
    public static SpawnPointController spawnPointController;

    private bool test = true;

    void Start() {
        
        if (spawnPointController == null) {
            spawnPointController = this;
        }
        else {
            Debug.LogError("More than one spawn controller in application.");
        }

        spawnPoints = GetComponentsInChildren<WaveSpawner>();
        Debug.Log("Size of spawn points is " + spawnPoints.Length); 
    }

    public void Update() {
        if(test) {
            NextWave();
        }
        test = false;
    }

    public void NextWave() {
        Debug.Log("Spawning waves");
       foreach (WaveSpawner spawner in spawnPoints) {
            StartCoroutine(spawner.SpawnWave(2));
        }
    }
}
