using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour, Trap
{
    public float force;
    public float cooldownOffset;
    public GameObject projectile;
    private Vector3 direction;
    private float timer;
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
        if (Time.time >= timer + cooldownOffset)
        {
            GameObject shot = ObjectPooler.Instance.SpawnFromPool(projectile.name, transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().AddForce(direction * force);
            timer = Time.time;
        }
    }
}
