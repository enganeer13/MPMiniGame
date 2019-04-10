using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbine : AutoTrap, Trap
{
    public Wind wind;
    public ParticleSystem particles;
    public float force = 10f;
    public bool active;
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
        if (active)
            fanOn();
        else
            fanOff();
        if (automatic)
            activate();
    }
    void fanOff()
    {
        active = false;
        windBox.enabled = false;
        particles.enableEmission = false;
    }

    void fanOn()
    {
        active = true;
        windBox.enabled = true;
        particles.enableEmission = true;
    }

    void toggleFan()
    {
        //activate wind hitbox
        windBox.enabled = windBox.enabled ? false : true;
        particles.enableEmission = particles.enableEmission ? false : true;
        active = active ? false : true;
    }

    public override void activateOnce()
    {
        toggleFan();
    }
  
}
