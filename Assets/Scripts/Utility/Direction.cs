using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientation
{
    Vertical,
    Horizontal
}

public class Direction
{
    private Vector2 directionVector;

    private Orientation orientation;

    private float rotation;

    public Direction(Vector2 v, Orientation o, float r)
    {
        directionVector = v;
        orientation = o;
        rotation = r;
    }

    public Vector2 MyDirectionVector => directionVector;

    public Orientation MyOrientation => orientation;

    public float MyRotation => rotation;
}
