using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public static GameSetup GS;
    public Transform[] spawnPointsTrapMaster;
    public int nextPlayersTeam;
    public Transform[] spawnPointsRunners;

    private void OnEnable()
    {
        if(GameSetup.GS == null)
        {
            GameSetup.GS = this;
        }
    }

    public void UpdateTeam()
    {
        if(nextPlayersTeam == 1)
        {
            nextPlayersTeam = 2;
        }

    }
}
