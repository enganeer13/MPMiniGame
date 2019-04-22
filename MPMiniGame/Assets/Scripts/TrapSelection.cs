using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSelection : MonoBehaviour
{
    public float fadeSpeed = 1f;

    private SpriteRenderer rend;
    private SpriteRenderer arrowRend1;
    private SpriteRenderer arrowRend2;
    private Sprite selectedTrap;
    private bool fade;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        arrowRend1 = transform.Find("SelectRight").GetComponent<SpriteRenderer>();
        arrowRend2 = transform.Find("SelectLeft").GetComponent<SpriteRenderer>();
        fade = true;
    }

    void Update()
    {
        float step = fadeSpeed * Time.deltaTime;

        if (fade)
        {
            rend.color = new Color(1f, 1f, 1f, Mathf.Lerp(rend.color.a, 0f, step));
            arrowRend1.color = new Color(1f, 1f, 1f, Mathf.Lerp(rend.color.a, 0f, step));
            arrowRend2.color = new Color(1f, 1f, 1f, Mathf.Lerp(rend.color.a, 0f, step));
        }
    }

    public void ChangeTrap(GameObject trap)
    {
        fade = false;
        rend.color = new Color(1f, 1f, 1f, 1f);
        arrowRend1.color = new Color(1f, 1f, 1f, 1f);
        arrowRend2.color = new Color(1f, 1f, 1f, 1f);
        selectedTrap = trap.GetComponent<SpriteRenderer>().sprite;
        rend.sprite = selectedTrap;
        fade = true;
    }
}
