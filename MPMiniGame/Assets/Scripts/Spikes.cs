using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : AutoTrap
{
    public bool active;
    public GameObject spikes;
    private Vector3 direction;
    private Vector3 defaultRelative;
    private BoxCollider2D spikesCollider;
    // Start is called before the first frame update
    void Start()
    {
        //Calculate direction to send spikes
        direction = Vector3.zero;
        float degrees = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        direction.x = Mathf.Cos(degrees);
        direction.y = Mathf.Sin(degrees);
        direction.Normalize();
        //Get default spike resting position
        spikesCollider = spikes.GetComponentInChildren<BoxCollider2D>();
        defaultRelative = transform.position - spikes.transform.position;
        //Set spikes triggered by default if active is true
        if (active)
            triggerSpikes();
        else
            retractSpikes();
        if (automatic)
            activate();
    }
    void readySpikes()
    {
        spikes.transform.position = transform.position - defaultRelative + direction * .15f;
    }
    
    //activate trap
    void triggerSpikes()
    {
        active = true;
        spikes.transform.position = transform.position - defaultRelative + direction * .75f;
        spikesCollider.enabled = true;
    }

    //deactiveate trap
    void retractSpikes()
    {
        active = false;
        spikes.transform.position = transform.position - defaultRelative;
        spikesCollider.enabled = false;
    }

    void toggleSpikes()
    {
        spikes.transform.position = active ? transform.position - defaultRelative : transform.position - defaultRelative + direction * .75f;
        active = active ? false : true;
        spikesCollider.enabled = spikesCollider.enabled ? false : true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!automatic && !active && collision.GetComponent<playerMovement>())
        {
            activateOnce();
        }
    }

    public override void activateOnce()
    {
        if (!automatic && !active)
        {
            readySpikes();
            Invoke("triggerSpikes", cooldownOffset);
            Invoke("retractSpikes", cooldownOffset * 2);
            timer = Time.time + cooldownOffset;
        }
        else if (automatic)
        {
            toggleSpikes();
        }
    }
}
