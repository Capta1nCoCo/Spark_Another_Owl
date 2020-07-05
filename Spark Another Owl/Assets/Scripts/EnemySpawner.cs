using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] List<GameObject> enemiesToSpawn = new List<GameObject>();
    [SerializeField] Text scoreText;
    [SerializeField] AudioClip spawnedEnemySFX;
    int enemyCounter = 0;    

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = enemyCounter.ToString();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        foreach (GameObject enemyToSpawn in enemiesToSpawn)
        {
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var spawnedEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            spawnedEnemy.transform.parent = gameObject.transform;
            AddScore();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        enemyCounter++;
        scoreText.text = enemyCounter.ToString();
    }
}
