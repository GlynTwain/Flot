using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class OiPizdes : Photon.MonoBehaviour
{
    public static int Mode = 1;
    public string OutputWord;
    public GenPole2 genPole2;
    public GameObject[] pointfSpawn;
    public PhotonView photonV;
    [SerializeField]
    private Pl _player;
    public Text OutputWordUIText;
    public InputField InputWordChash;
    public string InputWord;
    public int CreateWord;

    private void Start()
    {
        this.genPole2 = GameObject.Find("Zero_Full_30-15").GetComponent<GenPole2>();
    }

    public void SetPl(Pl _playerObj)
    {
        this._player = _playerObj;
    }

    private void Update()
    {
        this.Uiu(this.CreateWord);
        this.photonV.RPC("Uiu", PhotonTargets.All, new object[1]
        {
      (object) this.CreateWord
        });
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting & PhotonNetwork.isMasterClient)
            stream.SendNext((object)this.OutputWord);
        if (PhotonNetwork.isMasterClient || !stream.isReading)
            return;
        this.OutputWord = stream.ReceiveNext().ToString();
    }

    [PunRPC]
    public void Uiu(int CrWd)
    {
        if (CrWd == 0)
        {
            if (PhotonNetwork.isMasterClient)
            {
                Debug.Log((object)"Uiu со стороны севрера");
                switch (OiPizdes.Mode)
                {
                    case 1:
                        System.Random random1 = new System.Random();
                        string[] strArray1 = File.ReadAllLines("C:/Games/Flot/easy.txt");
                        this.OutputWord = strArray1[random1.Next(0, strArray1.Length)];
                        break;
                    case 2:
                        System.Random random2 = new System.Random();
                        string[] strArray2 = File.ReadAllLines("C:/Games/Flot/normally.txt");
                        this.OutputWord = strArray2[random2.Next(0, strArray2.Length)];
                        break;
                    case 3:
                        System.Random random3 = new System.Random();
                        string[] strArray3 = File.ReadAllLines("C:/Games/Flot/difficultly.txt");
                        this.OutputWord = strArray3[random3.Next(0, strArray3.Length)];
                        break;
                    case 4:
                        System.Random random4 = new System.Random();
                        string[] strArray4 = File.ReadAllLines("C:/Games/Flot/rand.txt");
                        this.OutputWord = strArray4[random4.Next(0, strArray4.Length)];
                        break;
                }
            }
            else
            {
                Debug.Log((object)"Uiu со стороны клиента");
                PhotonStream stream = new PhotonStream(true, (object[])null);
                PhotonMessageInfo info = new PhotonMessageInfo();
                stream.Serialize(ref this.OutputWord);
                this.OnPhotonSerializeView(stream, info);
            }
            this.OutputWordUIText.text = this.OutputWord;
            CrWd = 1;
            Debug.Log((object)("Uiu закончен слово = " + this.OutputWord));
            this.CreateWord = 1;
            InputWordChash.ActivateInputField();
        }
        this.OutputWordUIText.text = this.OutputWord;
    }

    [PunRPC]
    public void SlovoCheck()
    {
        this.InputWord = this.InputWordChash.text;
        if (string.CompareOrdinal(this.InputWord, this.OutputWord) != 0)
        {
            if (this.photonV.isMine)
                Debug.Log((object)"Слово не соответствует");
        }
        else if (string.CompareOrdinal(this.InputWord, this.OutputWord) == 0)
        {
            this.InputWordChash.text = string.Empty;
            Debug.Log("Очистил поле ввода");
            if (this.photonV.isMine)
            {
                Debug.Log("Начал Прибавлять очки");
                this._player.AddPoint();
                Debug.Log((object)"Слово соответствует, начал прибавлять очки");
            }
            this.CreateWord = 0;
            this.photonV.RPC("Uiu", PhotonTargets.All, new object[1]
            {
        (object) this.CreateWord
            });
        }
        Debug.Log((object)"Метод SlovoCheck закончен");
    }

    [PunRPC]
    public void TestSpaces()
    {
        Debug.Log("TestSpaces");
        this._player.AddPoint();
        Debug.Log("TestSpaces Ext");

    }


}
