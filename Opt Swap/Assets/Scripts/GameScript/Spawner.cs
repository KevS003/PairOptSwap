using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    //make inconsistent and random
    //Send movement information to enemy 
    public Vector3 spawnerDirection;//NEED THIS NUMBER TO GET ENEMY MOVING THE CORRECT DIRECTION
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject enemyRef;

    
    [SerializeField]
    private float minSpawnTime, maxSpawnTime;

    [SerializeField]
    private float spawnCounter;
    private void Awake()
    {
        spawnCounter = Random.Range(minSpawnTime, maxSpawnTime);
        //Enemy newEnemy = Creator.Create(enemyPrefab.gameObject).GetComponent<Enemy>();
    }



    private void Update()
    {
        spawnCounter -= Time.deltaTime;

        if (spawnCounter <= 0f)
        {
            spawnCounter = Random.Range(minSpawnTime, maxSpawnTime);
            enemyRef = Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);
            enemyRef.GetComponent<Enemy>().SetUpEnemy(spawnerDirection);

            //Enemy newEnemy = CreateEnemy();

            //newEnemy.transform.position = spawnPoint;

            //Color newColor = colors[Random.Range(0, colors.Count)];
            //newEnemy.SetUpEnemy(newColor);
        }
    }
}
