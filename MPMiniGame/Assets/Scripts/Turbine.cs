using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbine : MonoBehaviour, Trap
{
    public Wind wind;
    public ParticleSystem particles;
    public float force = 10f;
    bool toggle;
    BoxCollider2D windBox;
    
    public void Start()
    {
        //Calculate direction to push
        Vector3 direction = Vector3.zero;
        float degrees = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        direction.x = Mathf.Cos(degrees);
        direction.y = Mathf.Sin(degrees);
        direction.Normalize();
        //Initialize wind child Object
        wind.direction = direction;
        wind.force = force;
        windBox = wind.hitbox;
        particles.enableEmission = false;
        windBox.enabled = false;
    }
    public void activate()
    {
        windBox.enabled = windBox.enabled ? false : true;
        particles.enableEmission = particles.enableEmission ? false : true;
    }
  
}
