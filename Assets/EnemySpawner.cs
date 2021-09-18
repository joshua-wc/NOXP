using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject spawnPoint;
    public float secondsBetweenSpawns;
    public bool activated;

    float secondsSinceLastSpawn;
    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastSpawn = 0;
    }

    private void Awake()
    {
        References.spawner = this;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (activated)
        {


            secondsSinceLastSpawn += Time.fixedDeltaTime;
            if (secondsSinceLastSpawn >= secondsBetweenSpawns)
            {
                Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                secondsSinceLastSpawn = 0;
            }
        }
    }

}