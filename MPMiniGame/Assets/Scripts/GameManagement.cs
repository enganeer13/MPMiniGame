using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    GameObject mainCamera;
    scroll scroll;

    GameObject[] players;
    playerMovement[] playerMovement;

    GameObject trapMaster;
    TrapMaster trapMasterControl;

    GameObject countDown;
    Countdown countDownText;

    GameObject roundOver;
    RoundOver roundOverText;

    float timer = 3.0f;
    bool inCountdown = true;
    bool roundIsOver = false;

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

        countDown = GameObject.Find("Countdown");
        countDownText = countDown.GetComponent<Countdown>();

        roundOver = GameObject.Find("RoundOver");
        roundOverText = roundOver.GetComponent<RoundOver>();

    }


    void Update()
    {
        timer -= 1 * Time.deltaTime;
        double count = Math.Ceiling(timer);

        if(inCountdown == true)
        {
            if (timer > 0)
            {
                countDownText.countdownMessage(count.ToString());
            }
            else
            {
                countDownText.countdownMessage("Start!");
                scroll.enabled = true;

                for (int i = 0; i < playerMovement.Length; i++)
                {
                    if (playerMovement[i] != null)
                    {
                        playerMovement[i].enabled = true;
                    }
                }

                trapMasterControl.enabled = true;
            }
            if (timer <= -1)
            {
                countDownText.countdownMessage("");
                inCountdown = false;
            }
        }

        if (timer <= 0 && roundIsOver == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void endRound()
    {
        roundOverText.endRoundMessage();
        scroll.enabled = false;
        trapMasterControl.enabled = false;
        timer = 3;
        roundIsOver = true;
    }
}
