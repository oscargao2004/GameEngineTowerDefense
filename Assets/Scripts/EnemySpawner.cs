using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int spawnDelay = 1;
    List<GameObject> enemies = new List<GameObject>();

    private EnemyFactory basicFactory = new BasicEnemyFactory();
    private EnemyFactory bruteFactory = new BruteEnemyFactory();
    private EnemyFactory bossFactory = new BossEnemyFactory();

    private void Awake()
    {
        basicFactory.LoadData();
        bruteFactory.LoadData();
        bossFactory.LoadData();
    }

    void Start()
    {
        InitializeEnemies(basicFactory, 10);
        InitializeEnemies(bruteFactory, 5);
        InitializeEnemies(bossFactory, 1);

        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].SetActive(true);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void InitializeEnemies(EnemyFactory factory, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = factory.CreateEnemy();
            GameObject go = Instantiate(enemy, transform.position, Quaternion.identity, transform);
            enemies.Add(go);
            go.SetActive(false);
        }
    }

}
