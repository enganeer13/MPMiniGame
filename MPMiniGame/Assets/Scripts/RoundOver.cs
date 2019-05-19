using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundOver : MonoBehaviour
{
    Text roundOverText;

    void Start()
    { 
        roundOverText = GetComponent<Text>();
        roundOverText.text = "";
    }

    public void endRoundMessage()
    {
        roundOverText.text = "Dead!\nNext Round!";
    }
}
