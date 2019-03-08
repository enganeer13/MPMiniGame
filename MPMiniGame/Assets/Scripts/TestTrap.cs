using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrap : MonoBehaviour, Trap
{
    public void activate()
    {
        Debug.Log("TRAPPED");
    }
}
