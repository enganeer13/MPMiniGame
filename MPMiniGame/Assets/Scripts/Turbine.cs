using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbine : MonoBehaviour, Trap
{
    public BoxCollider2D trigger;
    public BoxCollider2D collider;
    public ParticleSystem particles;
    public float force = 10f;
    bool toggle;
    Vector3 direction;
    
    public void Start()
    {
        float degrees = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        //Calculate direction to push
        direction.x = Mathf.Cos(degrees);
        direction.y = Mathf.Sin(degrees);
        direction.Normalize();

        collider.enabled = true;
        trigger.enabled = false;
        particles.enableEmission = false;
        
    }
    public void activate()
    {
        trigger.enabled = trigger.enabled ? false : true;
        collider.enabled = collider.enabled ? false : true;
        particles.enableEmission = particles.enableEmission ? false : true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
            col.attachedRigidbody.AddForce(force * direction);
    }
}
