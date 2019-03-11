using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decTime;
    public float minTime = 1.00f;

    public GameObject gameOver;

    private void Update()
    {
        if(timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }

        if(gameOver.activeSelf == true)
        {
            Destroy(this);
        }
    }
}
