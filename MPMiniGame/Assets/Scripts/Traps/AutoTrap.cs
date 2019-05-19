using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AutoTrap : MonoBehaviour, Trap
{
    protected float timer;
    public bool automatic;
    public float cooldownOffset;
    private bool trapping;

    public void activate()
    {
        //activates trap once if trap is not automatic
        if (!automatic && !trapping && Time.time > timer)
        {
            activateOnce();
            timer = Time.time + cooldownOffset;
        }
        else if (automatic && !trapping)
        {
            InvokeRepeating("activateOnce", 0.00001f, cooldownOffset);
            trapping = true;
        }
    }

    public abstract void activateOnce();
}
