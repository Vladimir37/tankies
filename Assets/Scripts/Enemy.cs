using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tank
{
    public void Init()
    {
        // DEBUG DATA
        TankInitialize(DirectionManager.Instance.Directions[CardinalPoint.South], 3, 5, 1);
    }
}
