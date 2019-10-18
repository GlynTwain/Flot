using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Pl : Photon.MonoBehaviour {

    private Pl _myPlayer;

    public Text playerName;
    [SerializeField]private Text scoreText;
    private OiPizdes oiPizdes;
    public PhotonView photonV;
    [SerializeField] private string plname;
    [SerializeField] private int score;
    public int idPlayer;
    public int CreateWord = 0;
    private GameObject per;
    public Text OutputWordUIText;
    public InputField InputWordChash;
    public string InputWord;
    public string OutputWord;




    private void Awake()
    {
        _myPlayer = GetComponent<Pl>();

        photonV.owner.Set(PlayerProperty.Name, PhotonNetwork.playerName);
        photonV.owner.Set(PlayerProperty.Score, score);
        //RefreshPlayerInf();
        plname = PhotonNetwork.playerName;

        
    }

    public void RefreshPlayerInf()
    {
        if (photonV.isMine)
        {
            photonV.owner.Set(PlayerProperty.Score, score);
            score = photonView.owner.Get<int>(PlayerProperty.Score);
            scoreText.text = score.ToString();
        }
        else if (!photonV.isMine)
        {
            scoreText.text = photonView.owner.Get<int>(PlayerProperty.Score).ToString();
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }

    private void Start()
    {
        oiPizdes = GameObject.FindGameObjectWithTag("Canvases").GetComponent<OiPizdes>();
        oiPizdes.SetPl(_myPlayer);
        idPlayer = photonV.owner.ID;
        for (int i = 0; i <= oiPizdes.pointfSpawn.Length-1; i++)
        {
            if (oiPizdes.pointfSpawn[i].transform.childCount == 0)
            {
                this.gameObject.transform.SetParent(oiPizdes.pointfSpawn[i].transform);
                this.gameObject.transform.position = oiPizdes.pointfSpawn[i].transform.position;
                this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            }
        }
        if (!photonV.isMine)
        {
            playerName.text = photonView.owner.name;// Передаем введеные ники других игроков? 
        }
        else if (photonV.isMine)
        {
            playerName.text = plname; // Передаем введёный ник в поле для его отображения в комнате
            /*
            per = new GameObject("Score(" + idPlayer + ")");
            per.transform.SetParent(this.gameObject.transform);
            per.transform.localScale = new Vector3(1f, 1f, 1f);
            per.transform.position = new Vector3(4f, -1f, 0);
            per.AddComponent<Text>();
            per.GetComponent<Text>().color = new Color(50f, 50f, 50f);
            per.AddComponent<CanvasRenderer>();
            per.AddComponent<RectTransform>();
            per.AddComponent<PhotonView>();
            per.AddComponent<ScoreAdder>();
            scoreText = per.GetComponent<Text>();
            per.GetComponent<ScoreAdder>().PV();
           */

        }
        RefreshPlayerInf();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.KeypadEnter)) // кнопки для нажатий
        {
            oiPizdes.photonV.RPC("SlovoCheck", PhotonTargets.All);// Вызываю у всех игроков проверку введённого
            //Debug.Log("oiPizdes.photonV.RPC(SlovoCheck, PhotonTargets.All);// Вызываю у всех игроков проверку введённого");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (photonV.isMine)
            {
                Debug.Log("Начал прибавление очков игроку "+idPlayer);
                oiPizdes.photonV.RPC("TestSpaces", PhotonTargets.All);// Вызываю у всех игроков проверку введённого
                photonV.owner.Set(PlayerProperty.Score, score);
            }
            else if (!photonV.isMine)
            {
                scoreText.text = photonView.owner.Get<int>(PlayerProperty.Score).ToString();
            }
            //RefreshPlayerInf(); // 300 fps
        }
        RefreshPlayerInf();// 200 fps
        scoreText.text = score.ToString();
    }

    public void AddPoint()
    {
        score++;
        Debug.Log("Добавил очко");
    }
}
