using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : AutoTrap
{
    public float force;
    public float radius;
    public bool active;
    public BlackHolePull pull;
    ParticleSystem particles;
    CircleCollider2D hitbox;
    ParticleSystem.ShapeModule shapeModule;
    // Start is called before the first frame update
    void Start()
    {
        //Initialize child pull hitbox
        hitbox = pull.hitbox;
        hitbox.radius = radius;
        pull.force = force;
        particles = GetComponent<ParticleSystem>();
        shapeModule = particles.shape;
        shapeModule.radius = radius;
        if (active)
            pullOn();
        else
            pullOff();
        if (automatic)
            activate();
    }

    void pullOn()
    {
        hitbox.enabled = true;
        particles.Play();
    }

    void pullOff()
    {
        hitbox.enabled = false;
        particles.Stop();
    }

    void togglePull()
    {
        hitbox.enabled = hitbox.enabled ? false : true;
        if (hitbox.enabled)
            particles.Play();
        else
            particles.Stop();
    }

    public override void activateOnce()
    {
        togglePull();
    }
    
}
