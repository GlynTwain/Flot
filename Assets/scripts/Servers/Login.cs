using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : Photon.MonoBehaviour {

    [SerializeField] private Text connectText;

    private void Start()
    {
        PhotonNetwork.autoJoinLobby = false;// выключает авто подключение к лобби        
        PhotonNetwork.ConnectUsingSettings("ver. 1"); // для разделения игроков по версиям игры .. НЕОБХОДИМО ПРИ ОБНОВЛЕНИИ ИСПРАВЛЯТЬ .. 

    }

    private void OnConnectedToServer()
    {
        Debug.Log("Connected server OK");
    }

    private void Update()
    {
        connectText.text = PhotonNetwork.connectionStateDetailed.ToString();
    }


}
