using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonLobbyCustomMatch : MonoBehaviourPunCallbacks, ILobbyCallbacks
{

	public static PhotonLobbyCustomMatch lobby;

    public string roomName;
    public int roomSize;
    public GameObject roomListingPrefab;
    public Transform roomsPanel;

    private void Awake()
    {
        lobby = this; //creates a singleton, lives within the emain menu scene
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Connects to Master photon server
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon master server");
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        RemoveRoomListings();
        foreach(RoomInfo room in roomList)
        {
            ListRoom(room);
        }
    }

    void RemoveRoomListings()
    {
        while(roomsPanel.childCount != 0)
        {
            Destroy(roomsPanel.GetChild(0).gameObject);
        }
    }

    void ListRoom(RoomInfo room)
    {
        if(room.IsOpen && room.IsVisible)
        {
            GameObject tempListing = Instantiate(roomListingPrefab, roomsPanel);
            RoomButton tempButton = tempListing.GetComponent<RoomButton>();
            tempButton.roomName = room.Name;
            tempButton.roomSize = 4;
            tempButton.SetRoom();
        }
    }

    public void CreateRoom()
    {
        Debug.Log("Trying to create a new Room");

        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte) roomSize };
        PhotonNetwork.CreateRoom(roomName, roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a new room but failed. There must be a room with the same name");
        //CreateRoom();
    }

    public void OnRoomNameChanged(string nameIn)
    {
        roomName = nameIn;
    }

    public void OnRoomSizeChanged(string sizeIn)
    {
        roomSize = int.Parse(sizeIn);
    }

    public void JoinLobbyOnClick()
    {
        if(!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }
}
