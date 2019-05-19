using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileModifier : MonoBehaviour
{
    public GameObject modifier;
    //(Try to) detect tile hit and spawn tile mod on it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Tilemap tileMap = collision.gameObject.GetComponent<Tilemap>();
        if (tileMap)
        {
            Vector3 v = collision.GetContact(0).point;
            v = tileMap.GetCellCenterWorld(tileMap.WorldToCell(v));
            ObjectPooler.Instance.SpawnFromPool(modifier.name, v, Quaternion.identity);
            gameObject.SetActive(false);
        }
           else if(collision.gameObject.layer == 8)
        {
            GameObject mod = ObjectPooler.Instance.SpawnFromPool(modifier.name, collision.transform.position, Quaternion.identity);
            mod.transform.parent = collision.transform;
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
