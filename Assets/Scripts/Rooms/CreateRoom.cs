using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class CreateRoom : MonoBehaviourPunCallbacks
{
    
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Se conectó al servidor");
        //JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No se encontro una sala. Creando una sala nueva...");
        CreateRandomRoom();
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void CreateRandomRoom()
    {
        string roomName = "Room" + Random.Range(1, 1000); 
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 10 
        };

        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Entraste a la sala: " + PhotonNetwork.CurrentRoom.Name);
    }

    //Salir de la sala: debe ir atachado a un boton

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("Saliste de la sala: " + PhotonNetwork.CurrentRoom.Name);
    }
}

