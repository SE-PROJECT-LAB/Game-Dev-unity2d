using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    [HideInInspector]
    public GameObject spawnedEnemy;
    public Transform[] spawners;
    [HideInInspector]
    public int randomEnemy;
    [HideInInspector]
    public int randomSpawner;
    public int randomSide;
    public int spawnerCount=0;
    public int spawnerLimit=20;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies() 
    {
        while(spawnerCount<spawnerLimit) 
        {
            spawnerCount++;
            Debug.Log(spawnerCount);
            yield return new WaitForSeconds(Random.Range(1,3));
            randomEnemy = Random.Range(0, enemies.Length);
            randomSpawner = Random.Range(0, spawners.Length);
            randomSide=Random.Range(0,4);
            spawnedEnemy = Instantiate(enemies[randomEnemy]);
            Debug.Log(spawnedEnemy);
            spawnedEnemy.transform.position = spawners[randomSpawner].position;
            spawnedEnemy.GetComponent<CharacterMovement>().speed = Random.Range(4, 10);
            //left
            // if(randomSide==0)
            // {
            //      spawnedEnemy.GetComponent<EnemyMovement>().speed = -Random.Range(4, 10);
            //      spawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            // }
            // //right
            // else if(randomSide==0)
            // {
               
            // }
            // //top
            // else if(randomSide==0)
            // {
                
            // }
            // //bottom
            // else
            // {
                
            // }
        }
    }
    
}

   