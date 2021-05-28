using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQ : Damageable
{
    // Start is called before the first frame update
    void Start()
    {
        // DEBUG
        HealthInit(1);
    }

    public override void Death()
    {
        base.Death();
        
        GameManager.Instance.LoseTheGame(GameManager.DefeatTypes.HQDestroyed);
    }
}
