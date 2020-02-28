using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour {
    public static WaveSpawner[] spawnPoints;
    public static SpawnPointController spawnPointController;


    void Awake() {
        
        if (spawnPointController == null) {
            spawnPointController = this;
        }
        else {
            Debug.LogError("More than one card controller in application.");
        }

        spawnPoints = GetComponentsInChildren<WaveSpawner>();
    }

    public void NextWave() {
       foreach (WaveSpawner spawner in spawnPoints) {
            StartCoroutine(spawner.SpawnWave());
        }
    }
}
