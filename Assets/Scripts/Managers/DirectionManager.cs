using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardinalPoint
{
    North,
    South,
    West,
    East
}

public class DirectionManager : MonoBehaviour
{
    private static DirectionManager instance;

    public static DirectionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DirectionManager>();
            }

            return instance;
        }
    }

    public Dictionary<CardinalPoint, Direction> Directions => directions;

    private readonly Dictionary<CardinalPoint, Direction> directions = new Dictionary<CardinalPoint, Direction>()
    {
        {CardinalPoint.North, new Direction(Vector2.up, Orientation.Vertical, 0)},
        {CardinalPoint.South, new Direction(Vector2.down, Orientation.Vertical, 180)},
        {CardinalPoint.West, new Direction(Vector2.left, Orientation.Horizontal, 90)},
        {CardinalPoint.East, new Direction(Vector2.right, Orientation.Horizontal, 270)}
    };
}
