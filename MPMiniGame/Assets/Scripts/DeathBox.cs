using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    GameObject gameManager;
    GameManagement gameManagement;


    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        gameManagement = gameManager.GetComponent<GameManagement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<playerMovement>())
        {
            die(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<playerMovement>())
        {
            die(collision.gameObject);
        }
    }

    protected void die(GameObject runner)
    {
        Debug.Log("DIE");
        runner.SetActive(false);
        gameManagement.endRound();
    }
}
