using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    private int health;
    
    public int Health => health;

    protected void HealthInit(int damageableHealth)
    {
        health = damageableHealth;
    }

    public virtual void Hit()
    {
        health -= 1;

        if (health <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Destroy(transform.gameObject);
    }
}
