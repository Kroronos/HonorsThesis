using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemeyPrefab;
    public Transform spawnPoint;

    public float waveInterval = 5f;

    private float timeTillNextWave = 2f;
    private int waveNumber = 1;


    private void Update() {
        if(timeTillNextWave <= 0f) {
            StartCoroutine(SpawnWave());
            timeTillNextWave = waveInterval; 
        }

        timeTillNextWave -= Time.deltaTime;
    }

    IEnumerator SpawnWave() {
        Debug.Log("Next Wave Started!");

        for(int i = 0; i < waveNumber; ++i) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        ++waveNumber;
    }
    void SpawnEnemy() {
        Instantiate(enemeyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
