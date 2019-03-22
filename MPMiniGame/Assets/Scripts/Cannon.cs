using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour, Trap
{
    public float force;
    public float cooldownOffset;
    public bool toggle;
    public string tag;
    private bool firing;
    private float timer;
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
        if (!toggle && Time.time > timer)
        {
            fire();
            timer = Time.time + cooldownOffset;
        }
        else if(!firing && toggle && Time.time > timer)
        {
            InvokeRepeating("fire", 0.00001f, cooldownOffset);
            firing = true;
        }
        else if(firing && toggle && Time.time > timer)
        {
            CancelInvoke();
            firing = false;
        }
        
    }

    void fire()
    {
        GameObject projectile = ObjectPooler.Instance.SpawnFromPool(tag, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(direction * force);
    }
}
