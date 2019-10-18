using System.Collections.Generic;
using UnityEngine;

public class RoomLayutGroup : MonoBehaviour {

    [SerializeField]
    private GameObject _roomListingPrefab;
    private GameObject RoomListingPrefab
    {
        get { return _roomListingPrefab; }
    }


    private List<RoomList> _roomListsButtons = new List<RoomList>();
    private List<RoomList> RoomListsButtons
    {
        get { return _roomListsButtons; }
    }

    private void OnReceivedRoomListUpdate()
    {
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        foreach(RoomInfo room in rooms)
        {
            RoomReceived(room);
        }
        RemoveOldrooms();
    }

    private void RoomReceived(RoomInfo room)
    {
        int index = RoomListsButtons.FindIndex(x => x.RoomName == room.Name);
        if (index == -1)
        {
            if (room.IsVisible && room.PlayerCount < room.MaxPlayers)
            {
                GameObject roomListingObj = Instantiate(RoomListingPrefab);
                roomListingObj.transform.SetParent(transform, false);

                RoomList roomList = roomListingObj.GetComponent<RoomList>();
                RoomListsButtons.Add(roomList);

                index = (RoomListsButtons.Count - 1);
            }
        }
        if (index != -1)
        {
            RoomList roomList = RoomListsButtons[index];
            roomList.SetRoomNameText(room.Name);
            roomList.Update = true;
        }
    }

    private void RemoveOldrooms()
    {
        List<RoomList> removeRoom = new List<RoomList>();

        foreach (RoomList roomList in RoomListsButtons)
        {
            if (!roomList.Update)
                removeRoom.Add(roomList);
            else
                roomList.Update = false;
        }

        foreach(RoomList roomList in removeRoom)
        {
            GameObject roomListingObj = roomList.gameObject;
            RoomListsButtons.Remove(roomList);
            Destroy(roomListingObj);
        }
    }
}
