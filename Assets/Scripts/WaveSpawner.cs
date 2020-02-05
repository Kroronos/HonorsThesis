using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Transform enemeyPrefab;

    private int waveNumber = 1;
    private float waveInterval = 0.5f;

    public IEnumerator SpawnWave() {
        Debug.Log("Next Wave Started!");

        for(int i = 0; i < waveNumber; ++i) { //loop controls number of spanwed enemies
            SpawnEnemy();
            yield return new WaitForSeconds(waveInterval);
        }

        ++waveNumber;
    }
    void SpawnEnemy() {
        Instantiate(enemeyPrefab, transform.position, transform.rotation);
    }
}
