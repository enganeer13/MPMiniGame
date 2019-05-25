using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    public PhotonView PV;
    public GameObject myAvatar;
    public int myTeam;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if(PV.IsMine)
        {
        PV.RPC("RPC_GetTeam", RpcTarget.MasterClient);
        }
        /*
        int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
        if (PV.IsMine)
        {
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player 1"),
                                                 GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        if (myAvatar == null && myTeam != 0)
        {
            if (myTeam == 1)
            {
                int spawnPicker = Random.Range(0, GameSetup.GS.spawnPointsTrapMaster.Length);
                if (PV.IsMine)
                {
                    myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TrapMaster"),
                                                         GameSetup.GS.spawnPointsTrapMaster[spawnPicker].position, GameSetup.GS.spawnPointsTrapMaster[spawnPicker].rotation, 0);
                }
            }

            else
            {
                int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
                if (PV.IsMine)
                {
                    myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player 1"),
                                                         GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
                }
            }
        }
    }

    [PunRPC]
    void RPC_GetTeam()
    {
        myTeam = GameSetup.GS.nextPlayersTeam;
        GameSetup.GS.UpdateTeam();
        PV.RPC("RPC_SentTeam", RpcTarget.OthersBuffered, myTeam);
    }

    [PunRPC]
    void RPC_SentTeam(int whichTeam)
    {
        //whichTeam = 2;
        myTeam = whichTeam;
    }

}
