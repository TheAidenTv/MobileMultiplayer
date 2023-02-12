using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView Player1;
    public PhotonView Player2;

    // Start is called before the first frame update
    void Start()
    {
        // try to connect
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        // We connected
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        int playerCount = PhotonNetwork.CountOfPlayersInRooms;

        if (playerCount >= 1)
            PhotonNetwork.Instantiate(Player2.name, Vector2.zero, Quaternion.identity);
        else
            PhotonNetwork.Instantiate(Player1.name, Vector2.zero, Quaternion.identity);
    }
}
