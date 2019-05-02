using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    GameObject mainCamera;
    scroll scroll;

    GameObject[] players;
    playerMovement [] playerMovement;

    GameObject trapMaster;
    TrapMaster trapMasterControl;

    float timer = 3.0f;
    Text countdownText;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        scroll = mainCamera.GetComponent<scroll>();

        players = GameObject.FindGameObjectsWithTag("Player");
        playerMovement = new playerMovement[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            playerMovement[i] = players[i].GetComponent<playerMovement>();
        }

        trapMaster = GameObject.FindGameObjectWithTag("TrapMaster");
        trapMasterControl = trapMaster.GetComponent<TrapMaster>();

        countdownText = GetComponent<Text>();
        countdownText.text = "";
    }


    void Update()
    {
        timer -= 1 * Time.deltaTime;
        double count = Math.Ceiling(timer);
        if (timer > 0)
        {
            countdownText.text = count.ToString();
        }
        else 
        {
            countdownText.text = "Start!";
            scroll.enabled = true;

            for (int i = 0; i < playerMovement.Length; i++)
            {
                playerMovement[i].enabled = true;
            }

            trapMasterControl.enabled = true;
        }
        if (timer <= -1)
        {
            countdownText.text = "";
        }
    }
}
