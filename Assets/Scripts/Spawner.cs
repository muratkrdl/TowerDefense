using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(1, 50)] int poolSize = 7;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 0.5f;


    GameObject[] pool;

    void Awake() 
    {
        PopulatePool();
    }
    void Start() 
    {
        StartCoroutine(EnemySpawner());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObject()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
    
    IEnumerator EnemySpawner()
    {
        while (true)
        {
            EnableObject();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
