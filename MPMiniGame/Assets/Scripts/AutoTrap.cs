using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AutoTrap : MonoBehaviour, Trap
{
    protected float timer;
    public bool automatic;
    public float cooldownOffset;
    private bool active;

    public void activate()
    {
        //activates trap once if trap is not automatic
        if (!automatic && Time.time > timer)
        {
            activateOnce();
            timer = Time.time + cooldownOffset;
        }
        else if (automatic && !active)
        {
            InvokeRepeating("activateOnce", 0.00001f, cooldownOffset);
            active = true;
        }
    }

    public abstract void activateOnce();
}
