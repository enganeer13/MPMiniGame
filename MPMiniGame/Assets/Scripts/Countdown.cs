using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    Text countdownText;

    void Start()
    {
        countdownText = GetComponent<Text>();
        countdownText.text = "";
    }

    public void countdownMessage(String txt)
    {
        countdownText.text = txt;
    }
}
