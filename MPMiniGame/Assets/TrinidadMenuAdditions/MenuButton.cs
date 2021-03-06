﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;
    bool mouseClick;
    public int desiredSceneIndex;
    float buttonDelay;

    // Update is called once per frame
    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            if (Input.GetAxis("Submit") == 1 || mouseClick == true)
            {
                animator.SetBool("pressed", true);
                mouseClick = false;
            }
            else if (animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);
                animatorFunctions.disableOnce = true;
                Invoke("changeScene", 0.4f);
                
                
            }
        } else {
            animator.SetBool("selected", false);
        }
    }

    public void changeScene()
    {
        if (desiredSceneIndex == 4)
        {
            Debug.Log("quit app");
            Application.Quit();
        }
        else
        {
            Debug.Log("change scene");
            SceneManager.LoadScene(desiredSceneIndex);
        }
    }

    public void MouseOver()
    {
        menuButtonController.index = thisIndex;
    }

    public void MouseClick()
    {
        mouseClick = true;
    }
}
