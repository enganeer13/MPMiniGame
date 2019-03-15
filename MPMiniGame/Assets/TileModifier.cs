using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileModifier : MonoBehaviour
{
    public GameObject modifier;
    public string tag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Tilemap tileMap = collision.gameObject.GetComponent<Tilemap>();
        if (tileMap)
        {
            GridLayout grid = tileMap.GetComponentInParent<GridLayout>();
            Vector3 v = grid.WorldToCell(collision.GetContact(0).point);
            v.x += .5f;
            v.y += .5f;
            ObjectPooler.Instance.SpawnFromPool(tag, v, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
