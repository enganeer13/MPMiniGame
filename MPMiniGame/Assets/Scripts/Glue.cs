using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue : MonoBehaviour
{
    public float defaultMovementSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement character = collision.GetComponent<playerMovement>();
        if(character)
        {
            character.runSpeed /= 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovement character = collision.GetComponent<playerMovement>();
        if (character)
        {
            character.runSpeed = defaultMovementSpeed;
        }
    }
}
