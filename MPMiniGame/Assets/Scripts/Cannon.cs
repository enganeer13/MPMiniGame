using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour, Trap
{
    public float force;
    public string tag;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        //Calculate direction to shoot
        direction = Vector3.zero;
        float degrees = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        direction.x = Mathf.Cos(degrees);
        direction.y = Mathf.Sin(degrees);
        direction.Normalize();
    }

    public void activate()
    {
        //Shoot projectile of tag in specified direction and force
        GameObject projectile = ObjectPooler.Instance.SpawnFromPool(tag, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(direction * force);
    }
}
