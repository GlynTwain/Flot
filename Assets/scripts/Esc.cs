using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc : MonoBehaviour {

    public GameObject EscGame;
    private bool actEscG = false;
    public GameObject InputField; 

    public void GoMeny()
    {
#pragma warning disable CS0618 // Тип или член устарел
        Application.LoadLevel(1);
        PhotonNetwork.Disconnect();
        //Debug.Log("Вы покинули комнату");
#pragma warning restore CS0618 // Тип или член устарел
    }
    public void GoDesctop()
    {
        Application.Quit();
    }
    public void GoGame()
    {
        GetComponent<Esc>();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            actEscG = !actEscG;
            EcsG();
        }
        
    }

    public void EcsG()
    {
        if (actEscG)
        {
            EscGame.SetActive(true);
            InputField.SetActive(false);
        }
        if (!actEscG)
        {
            EscGame.SetActive(false);
            InputField.SetActive(true);
        }
    }
}
