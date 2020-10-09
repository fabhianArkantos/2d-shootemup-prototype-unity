using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float secondsForSpawn = 5f;
    public GameObject enemyPrefab;

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsForSpawn);
            SpawnEnemy();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
