using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    private static MapManager instance;

    public static MapManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MapManager>();
            }

            return instance;
        }
    }

    [SerializeField]
    private Tilemap ground;

    [SerializeField]
    private Tilemap obstacles;
    
    public MapBoundaries GroundMapBoundaries { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        BoundsInt cellBounds = ground.cellBounds;

        MapCell min = new MapCell(cellBounds.min.x, cellBounds.min.y);
        MapCell max = new MapCell(cellBounds.max.x - 1, cellBounds.max.y - 1);

        GroundMapBoundaries = new MapBoundaries(min, max);
    }
}
