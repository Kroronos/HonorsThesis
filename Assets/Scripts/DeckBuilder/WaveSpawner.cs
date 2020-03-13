using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Enemy enemyPrefab;

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
        enemyPrefab.source = transform;
        Instantiate(enemyPrefab, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
    }
}
