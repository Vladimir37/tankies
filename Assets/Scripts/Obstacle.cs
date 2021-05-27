using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Damageable
{
    private void Start()
    {
        HealthInit(1);
    }
}
