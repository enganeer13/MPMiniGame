using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLabel : MonoBehaviour
{
    GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponentInParent<Cannon>().projectile;
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.sprite = projectile.GetComponent<SpriteRenderer>().sprite;
    }
}
