using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] List<GameObject> enemiesToSpawn = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        foreach (GameObject enemyToSpawn in enemiesToSpawn)
        {
            var spawnedEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            spawnedEnemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }        
    }   
}
