using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn_3 : MonoBehaviour
{
    public GameObject obstacle;
    public Transform left, right, top, bottom;
   // public float startingSpawnRate; //spawnRateIncreaseInterval;
    //public Transform spawnPoint;

    public float spawnInterval, difficultyIncreaseInterval;
    public int maxNoOfEnemies, totalEnemies;
    public static int currentNoOfEnemies;
    public GameObject bossEnemy;

    private float spawnTime, stageLength, readyForNextDifficultyIncrease;
    private int enemiesKilled;
        
    float spawnRate;
    float timeElapsed;

    bool enemiesStage;
    

    // Start is called before the first frame update
    private void Start()
    {
        spawnRate = 1 / spawnInterval;
        currentNoOfEnemies = 0;
        enemiesKilled = 0;
        enemiesStage = true;
        //stageLength = spawnRateIncreaseInterval;
    }
    // Update is called once per frame
    void Update()
    {

        // spawnRate += (1/ 1000) * Time.deltaTime;
        //print(spawnRate);

        timeElapsed += Time.deltaTime;
        //print(Mathf.RoundToInt(timeElapsed) % 4);
        //print(timeElapsed);
        //if (Mathf.RoundToInt(timeElapsed) % difficultyIncreaseRate == 0)
        //{
        //    spawnRate += 1/60;
        //    print(spawnRate);

        //}
        if (enemiesStage == true)
        {
            if (Time.time > readyForNextDifficultyIncrease)
            {
                readyForNextDifficultyIncrease = Time.time + difficultyIncreaseInterval;
                spawnRate += 0.5f;
                print(spawnRate);
            }
        }

        if (Time.time > spawnTime)
        {
            if(currentNoOfEnemies < maxNoOfEnemies)
            {
                Spawn();
                spawnTime = Time.time + 1/spawnRate;
                currentNoOfEnemies++;
                enemiesKilled++;
                print(enemiesKilled);
                if (enemiesKilled >= totalEnemies)
                {
                    spawnRate = 0;
                    enemiesStage = false;
                    bossEnemy.SetActive(true);
                }
                    //Time.timeScale = 0;

                //spawnRate++;
            }
            
        }



    }
    void Spawn()
    {
        float randomX = Random.Range(left.position.x, right.position.x);
        float randomY = Random.Range(bottom.position.y, top.position.y);
        Instantiate(obstacle, new Vector3(randomX, randomY, 0), transform.rotation);
    }

    public void reduceEnemies()
    {
        currentNoOfEnemies--;
        //print(currentNoOfEnemies);
    }
}
