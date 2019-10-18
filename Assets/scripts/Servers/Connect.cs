using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Connect : Photon.MonoBehaviour
{
    public InputField NameRoom;
    public InputField passwordRoom;

    public RoomOptions roomOptions;
    public Text inf;
    public RoomInfo[] roomList;

    [SerializeField] private GameObject Player;

    [SerializeField] private string LoginPl = "Дед";
    public GameObject netConnect;
    public Transform[] SpawnPoints;

    public Transform roomListHolder;

    private void Start()
    {
        NameRoom.text = "";
    }

    private void Update()
    {
        if (roomList != null)
        {
            for(int i = 0; i < roomList.Length; i++)
            {
                GameObject newButton = Instantiate((GameObject)Resources.Load("ButRoom"));
                newButton.transform.SetParent(roomListHolder);
                newButton.GetComponentInChildren<Text>().text = roomList[i].Name;
                newButton.GetComponent<ButRoom>().nameroom = roomList[i].Name;
            }
        }
        
    }

    public virtual void OnJoinedLobby()
    {
        inf.text = "Вы подключены в лобби";
    }

    public virtual void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        netConnect.SetActive(false);
        for(int i = 0; i < SpawnPoints.Length; i++)
        {
            if (SpawnPoints[i].childCount <= 0)
            {
                GameObject pl = PhotonNetwork.Instantiate(Player.name, SpawnPoints[i].transform.position, SpawnPoints[i].transform.rotation,1);
                Debug.Log(pl+" ? ");
                pl.transform.GetChild(2).GetComponent<Text>().text = LoginPl;
            }
            
        }
    }

    public void CreatGame()
    {
        if (PhotonNetwork.JoinLobby())
        {
            roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 4;//Максимально игроков
            roomOptions.PlayerTtl = 3000;// Если ливнул то через 3 сек удалится
            roomOptions.EmptyRoomTtl = 6000; // Сколько комната живет после выхода последнего игрока (6 сек)
            Debug.Log("O"+NameRoom.text+"O");

            if (NameRoom.text != "" & NameRoom.text != " ")
            {
                PhotonNetwork.CreateRoom(NameRoom.text, roomOptions, null);
                //PhotonNetwork.LoadLevel(1);
                Debug.Log("Create Room " + NameRoom.text + " Статус: " + PhotonNetwork.connectionStateDetailed.ToString());
            }
            else
            {
                inf.text = "Поле названия комнаты пустое";
            }
        }
        else
        {
            Debug.Log("Вы не присоеденились к серверу");
            inf.text = "Вы не присоеденились к серверу";

        }
    }

    public void JoinGame()
    {
        if (PhotonNetwork.JoinLobby())
        {
            if (NameRoom.text != "" & NameRoom.text != " ")
            {
                Debug.Log("!!!");
                PhotonNetwork.JoinRoom(NameRoom.text);
                Debug.Log("Join Room " + NameRoom.text + " Доп инфа: " + PhotonNetwork.Server.ToString());
            }
            else
            {
                inf.text = "Поле названия комнаты пустое";
            }
        }
        else
        {
            Debug.Log("Вы не присоеденились к серверу");
            inf.text = "Вы не присоеденились к серверу";


        }


    }

    public void ConnectGameRandom()
    {
        if (PhotonNetwork.JoinLobby())
        {
            if (roomList != null)
            {
                PhotonNetwork.JoinRandomRoom(); // к любой рандомной без фильтра;
            }
            else
            {
                inf.text = "Нету комнат";
                Debug.Log("Нет комнат");
            }

        }
        else
        {
            Debug.Log("Вы не присоеденились к серверу");
            inf.text = "Вы не присоеденились к серверу";

        }
    }

    
   
}
