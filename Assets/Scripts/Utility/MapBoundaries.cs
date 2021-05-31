using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBoundaries
{
    public MapCell Min { get; private set; }

    public MapCell Max { get; private set; }

    public MapBoundaries(MapCell minPoint, MapCell maxPoint)
    {
        Min = minPoint;
        Max = maxPoint;
    }
}

public class MapCell
{
    public int X { get; private set; }
    
    public int Y { get; private set; }

    public MapCell(int xPoint, int yPoint)
    {
        X = xPoint;
        Y = yPoint;
    }
}