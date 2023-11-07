
using System.Collections;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerController : MonoBehaviourPunCallbacks
{
    PhotonView PV;
    public GameObject[] obDeshab;
    public GameObject[] geometrias;
    public  MonoBehaviour[] scDeshab;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        if(!PV.IsMine) gameObject.name="jugador conectado " + Random.Range(0,100);
        if(PV.IsMine) gameObject.name="jugador propio";
    }

    void Start()
    {
        if(!PV.IsMine)
        {
            for(int i = 0; i<obDeshab.Length;i++){
                obDeshab[i].SetActive(false);
            }
            for(int i = 0; i<scDeshab.Length;i++){
                scDeshab[i].enabled=(false);
            }
            for(int i = 0; i<scDeshab.Length;i++){
                geometrias[i].layer=LayerMask.NameToLayer("Default");
            }
        }
    }

    void Update()
    {
        if(!PV.IsMine)
            return;
    }

    void FixedUpdate()
    {
        if(!PV.IsMine)
            return;
    }
}