﻿using UnityEngine.UI;
using UnityEngine;

public class RoomList : MonoBehaviour {

    [SerializeField]
    private Text _roomNameText;
    private Text RoomNameText
    {
        get { return _roomNameText; }
    }

    public string RoomName { get; private set; }
    public bool Update { get; set; }

    private void Start ()
    {
        GameObject lobbyCanvasObj = MainCanvasManager.Instance.LobbyCanvas.gameObject;
        if (lobbyCanvasObj == null)
        {
            return;
        }

        LobbyCanvas lobbyCanvas = lobbyCanvasObj.GetComponent<LobbyCanvas>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => lobbyCanvas.OnClickJoinRoom(RoomNameText.text));
	}

    private void OnDestroy()
    {
        Button button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
    }

    public  void SetRoomNameText(string text)
    {
        RoomName = text;
        RoomNameText.text = RoomName;
    }

    public void JoinRoon()
    {
        PhotonNetwork.JoinRoom(RoomName);
    }

    

}
