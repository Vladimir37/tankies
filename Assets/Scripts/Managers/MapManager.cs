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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public Vector3 GetTilePosition(Vector3Int target)
    // {
    //     return ground.GetTile(target);
    // }
}
