using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : DeathBox
{
    private bool canKill = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<playerMovement>() && canKill)
            die(collision.gameObject);
        else
            gameObject.SetActive(false);
    }
}
