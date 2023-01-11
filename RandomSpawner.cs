using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public double time = 2.5;
    public double initialTime1 = 10;
    public double initialTime2 = 5;
    public double currentTime;
    [SerializeField] public bool playing = true;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = initialTime1;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }

        if (currentTime < 0)
        {
            playing = !playing;
            if (playing)
            {
                currentTime = initialTime1;
            }
            else
            {
                currentTime = initialTime2;
            }
        }

        if (playing)
        {
            if (time < 0)
            {
                time = 2.5;
                int randEnemy = Random.Range(0, enemyPrefabs.Length);
                int randSpawnPoint = Random.Range(0, spawnPoints.Length);

                Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
            }

            if (time > 0)
            {
                time -= Time.deltaTime;
            }
        }
    }
}
