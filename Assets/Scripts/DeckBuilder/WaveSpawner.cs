using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Enemy enemeyPrefab;

    private float waveInterval = 0.5f;

    public IEnumerator SpawnWave(int waveNumber) {
        Debug.Log("Next Wave Started!");

        for(int i = 0; i < waveNumber; ++i) { //loop controls number of spanwed enemies
            SpawnEnemy();
            yield return new WaitForSeconds(waveInterval);
        }

        ++waveNumber;
    }
    void SpawnEnemy() {
        enemeyPrefab.source = transform;
        Instantiate(enemeyPrefab, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
    }
}
