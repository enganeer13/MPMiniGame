using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbine : MonoBehaviour, Trap
{
    public float force = 10f;
    bool toggle;
    Vector3 direction;
    BoxCollider2D trigger;
    BoxCollider2D collider;
    public void Start()
    {
        float degrees = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        //Calculate direction to push
        direction.x = Mathf.Cos(degrees);
        direction.y = Mathf.Sin(degrees);
        direction.Normalize();

        BoxCollider2D[] boxes = GetComponents<BoxCollider2D>();
        foreach(BoxCollider2D box in boxes)
        {
            if (box.isTrigger)
            {
                trigger = box;
                trigger.enabled = false;
            }
            else
            {
                collider = box;
            }
        }
    }
    public void activate()
    {
        trigger.enabled = trigger.enabled ? false : true;
        collider.enabled = collider.enabled ? false : true;
        //toggle = toggle ? false : true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
            col.attachedRigidbody.AddForce(force * direction);
    }
}
