using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelChunk : MonoBehaviour
{
    private int width;
    private Tilemap tileMap;
    // Start is called before the first frame update
    public int Awake()
    {
        tileMap = GetComponentInChildren<Tilemap>();
        tileMap.CompressBounds();
        width = tileMap.size.x;
        return 0;
    }

    public int getWidth()
    {
        return width;
    }
}
