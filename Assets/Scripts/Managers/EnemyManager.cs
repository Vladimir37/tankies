using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance;

    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EnemyManager>();
            }

            return instance;
        }
    }
    
    [SerializeField]
    private Spawner spawner;

    [SerializeField]
    private Text tankCountUI;
    
    private int maxEnemyCount;

    private int enemyCount;

    private int onetimeEnemyCount;
    
    private List<Enemy> currentEnemies = new List<Enemy>();
    
    // Start is called before the first frame update
    void Start()
    {
        // DEBUG
        maxEnemyCount = 10;
        
        onetimeEnemyCount = 4;

        tankCountUI.text = maxEnemyCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int missingTanks = onetimeEnemyCount - (currentEnemies.Count + spawner.enemyInQueue);
        
        if (missingTanks > 0)
        {
            if (currentEnemies.Count + missingTanks + spawner.enemyInQueue <= maxEnemyCount)
            {
                spawner.AddEnemiesInQueue(missingTanks);
            }
            else
            {
                spawner.AddEnemiesInQueue(maxEnemyCount - (currentEnemies.Count + spawner.enemyInQueue));
            }
        }

        if (maxEnemyCount <= 0 && currentEnemies.Count == 0 && spawner.enemyInQueue == 0)
        {
            GameManager.Instance.WinTheGame();
        }
        
        // foreach (Enemy enemy in currentEnemies)
        // {
        //     enemy.Attack();
        //     // Debug.Log(enemy.IsMoved);
        // }
    }
    
    public void AddTank(Enemy enemy)
    {
        currentEnemies.Add(enemy);
    }
    
    public void RemoveTank(Enemy enemy)
    {
        currentEnemies.Remove(enemy);
        maxEnemyCount--;
        tankCountUI.text = maxEnemyCount.ToString();
    }
}
