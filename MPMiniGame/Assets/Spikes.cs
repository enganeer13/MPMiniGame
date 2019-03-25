using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject spikes;
    public bool active;
    public float timer;
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
    }
    void readySpikes()
    {
        spikes.transform.position = transform.position - defaultRelative + direction * .3f;
    }
    
    //activate trap
    void triggerSpikes()
    {
        active = true;
        spikes.transform.position = transform.position - defaultRelative + direction;
    }

    //deactiveate trap
    void retractSpikes()
    {
        active = false;
        spikes.transform.position = transform.position - defaultRelative;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!active && collision.GetComponent<playerMovement>())
        {
            readySpikes();
            Invoke("triggerSpikes", timer);
            Invoke("retractSpikes", timer * 2);
        }
    }
}
