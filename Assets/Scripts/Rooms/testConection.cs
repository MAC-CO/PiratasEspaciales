using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class testConection : MonoBehaviourPunCallbacks
{
    //Script para conección al server, debe ir atachado a algun objeto
    void Start()
    {
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Conectado al servidor");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
       print("Se desconectó de servidor por " + cause.ToString());
    }


}

 

    

