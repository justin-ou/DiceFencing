using UnityEngine;
using System.Collections;

public class NetworkManager : Singleton<NetworkManager> {

    private bool _isHost = false;
    private bool _isInRoom = false;

    // Use this for initialization
    public void Connect() {
        PhotonNetwork.ConnectUsingSettings("0.1");        
    }
    public bool IsHost() {
        return _isHost;
    }

    void JoinRoom() {
        bool connected = PhotonNetwork.connectedAndReady && PhotonNetwork.room == null;

        if (connected) {
            Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
            //PhotonNetwork.JoinRoom(Config.BASIC_ROOM_NAME);
        }else{
            Debug.Log("Not connected or already in a room");
        }
    }

    void OnJoinedLobby() {
        Debug.Log("OnJoinedLobby() : Hey, You're in a Lobby ! " + PhotonNetwork.PhotonServerSettings.ServerAddress);
        JoinRoom();
    }
    void OnJoinedRoom() {
        Debug.Log("Room Joined");
        _isInRoom = true;

        //Player.Instance.Init(PhotonNetwork.playerList.Length);
    }
    void OnCreatedRoom() {
        Debug.Log("Room created (" + PhotonNetwork.room.name + ")");
        _isHost = true;
    }
    void OnPhotonJoinRoomFailed() {
        Debug.Log("Room Join Failed. Creating room...");
        PhotonNetwork.CreateRoom("RoomName");        
    }    
}
