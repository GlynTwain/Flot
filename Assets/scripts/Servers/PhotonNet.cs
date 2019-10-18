using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonNet : MonoBehaviour {

    public string versionName = "5.2";

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
        Debug.Log("Присоединение к фотону . . . ");
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Вы подключились к фотон мастеру");
    }

    private void OnJoinedLobby()
    {
        Debug.Log("Вы подключены к лобби");
    }

    private void OnPhotonCreateRoomFailed()
    {
        Debug.Log("Ошибка создания комнаты");
    }

    private void OnPhotonJoinRoomFailed(object[] codeAndMsg)
    {
        Debug.Log("Ошибка подключения к комнате: "+ codeAndMsg);
    }

    private void OnDisconnectedFromPhoton()
    {
        Debug.Log("Вы отключились от фотона");
    }
    
}
