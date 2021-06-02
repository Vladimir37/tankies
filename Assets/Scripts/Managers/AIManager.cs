using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    [SerializeField]
    private Enemy[] enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.Init();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.Attack();
            // Debug.Log(enemy.IsMoved);
        }
    }
}
