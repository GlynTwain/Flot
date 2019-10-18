using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PhotonHolder : Photon.MonoBehaviour {

    [SerializeField] private OiPizdes oiPizdes;
    public PhotonButtons photonB;
    [SerializeField] private GameObject Player;
    public string st = "";

    private void Awake()
    {
        DontDestroyOnLoad (this.transform);// Не уничтожать меня при смене сцены
        SceneManager.sceneLoaded += OnSceneFinishedLoading;// Назначения
    }

    public void OnClickCreateRoom()
    {
        RoomOptions roomOptions;

        roomOptions = new RoomOptions();

        roomOptions.customRoomProperties = new ExitGames.Client.Photon.Hashtable();
        roomOptions.customRoomProperties.Add(RoomProperty.Word  , st);

        roomOptions.MaxPlayers = 4;//Максимально игроков
        roomOptions.PlayerTtl = 3000;// Если ливнул то через 3 сек удалится
        roomOptions.EmptyRoomTtl = 6000;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        
        if (photonB.nameRoomInput.text != "" & photonB.nameRoomInput.text != " " & photonB.nameRoomInput.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(photonB.nameRoomInput.text, roomOptions, null);
           // Debug.Log("Create Room " + photonB.nameRoomInput.text + " Статус: " + PhotonNetwork.connectionStateDetailed.ToString());
        }
        else
        {
            photonB.inf.text = "Поле названия комнаты пустое";
        }
    }// Создание комнаты

    public void OnClickJoinRoom()
    {
        if (photonB.nameRoomInput.text != "" & photonB.nameRoomInput.text != " " & photonB.nameRoomInput.text.Length >= 1)
        {
            PhotonNetwork.JoinRoom(photonB.nameRoomInput.text);
            //Debug.Log("Join Room " + photonB.nameRoomInput.text + " Доп инфа: " + PhotonNetwork.Server.ToString());
        }
        else
        {
            photonB.inf.text = "Поле названия комнаты пустое";
        }
    }//Подключение к комнате

    public void MoveScene()
    {
        PhotonNetwork.LoadLevel(2);
    }//Переключение на сцену

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Lvl_1")
        {
            Debug.Log("Игра загружена, приятной игры");
            oiPizdes = GameObject.FindGameObjectWithTag("Canvases").GetComponent<OiPizdes>();
            spawnPlayer();
        }
    }// При успешном подключении к сцене

    private void spawnPlayer()
    {
        for(int i =0; i <= oiPizdes.pointfSpawn.Length; i++)
        {
            if (oiPizdes.pointfSpawn[i].transform.childCount == 0)
            {
                GameObject pl = PhotonNetwork.Instantiate(Player.name, oiPizdes.pointfSpawn[i].transform.position, oiPizdes.pointfSpawn[i].transform.rotation, 0);
                pl.transform.SetParent(oiPizdes.pointfSpawn[i].transform);
                pl.transform.position = oiPizdes.pointfSpawn[i].transform.position;
                pl.transform.localScale = new Vector3(1f,1f,1f);
                                
                break;
            }
            //Debug.Log(oiPizdes.pointfSpawn[i].transform.childCount);
            //Debug.Log("В масиве : "+oiPizdes.pointfSpawn.Length);

        }
        
    }// Создание игрока
}
