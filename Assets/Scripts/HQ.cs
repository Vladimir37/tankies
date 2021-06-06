using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQ : Damageable
{
    [SerializeField]
    private Transform hqAliveIcon;
    
    [SerializeField]
    private Transform hqDestroyedIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        HealthInit(1);
    }

    public override void Death()
    {
        hqAliveIcon.gameObject.SetActive(false);
        hqDestroyedIcon.gameObject.SetActive(true);

        GameManager.Instance.LoseTheGame(GameManager.DefeatTypes.HQDestroyed);
    }
}
