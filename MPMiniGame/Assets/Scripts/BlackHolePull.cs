using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHolePull : MonoBehaviour
{
    public CircleCollider2D hitbox;
    public float force;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //move everything in hitbox towards center
        Vector3 direction = -(collision.transform.position - transform.position);
        direction.Normalize();
        float mod = 1 - Vector3.Distance(collision.transform.position, transform.position)/hitbox.radius;
        mod = mod < 0 ? .25f : mod;
        collision.attachedRigidbody.AddForce(force * mod * direction);
    }
}
