using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject tankPrefab;

    [SerializeField] 
    private Transform[] spawnPoints;

    public int enemyInQueue { get; private set; }

    private float spawnCooldown;

    private float timeFromLastSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyInQueue = 0;
        spawnCooldown = 1;
        timeFromLastSpawn = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timeFromLastSpawn += Time.deltaTime;
        if (timeFromLastSpawn >= spawnCooldown && enemyInQueue > 0)
        {
            SpawnEnemy();
            timeFromLastSpawn = 0;
            enemyInQueue--;
        }
    }

    public void AddEnemiesInQueue(int count)
    {
        enemyInQueue += count;
    }

    private void SpawnEnemy()
    {
        Enemy enemy = Instantiate(tankPrefab, spawnPoints[0].transform.position, Quaternion.identity).GetComponent<Enemy>();
        enemy.Init();
        EnemyManager.Instance.AddTank(enemy);
    }
}
