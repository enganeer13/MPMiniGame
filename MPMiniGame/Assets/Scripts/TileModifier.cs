using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileModifier : MonoBehaviour
{
    public string tag;
    //(Try to) detect tile hit and spawn glue on it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Tilemap tileMap = collision.gameObject.GetComponent<Tilemap>();
        if (tileMap)
        {
            Vector3 v = collision.GetContact(0).point;
            v.y -= .5f;
            v.x =  v.x - tileMap.WorldToCell(collision.GetContact(0).point).x - 0.5f < tileMap.WorldToCell(collision.GetContact(0).point).x + 0.5f - v.x ? tileMap.WorldToCell(collision.GetContact(0).point).x - 0.5f : tileMap.WorldToCell(collision.GetContact(0).point).x + 0.5f;
            ObjectPooler.Instance.SpawnFromPool(tag, v, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
