using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCanvas : MonoBehaviour {

    [SerializeField]
    private RoomLayutGroup _roomLayutGroup;
    private RoomLayutGroup RoomLayutGroup
    {
        get { return _roomLayutGroup; }
    }

    public void OnClickJoinRoom(string roomName)
    {

    }
}
