using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue : MonoBehaviour
{
    float defaultMovementSpeed = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement character = collision.GetComponent<playerMovement>();
        if(character)
        {
            defaultMovementSpeed = character.runSpeed;
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
