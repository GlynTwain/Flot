using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonInf : MonoBehaviour {

    public InputField loginInpud;
    //private bool alreadyReg = false;
    //public bool removeUsername = false;
    public GameObject entercrBut;
    public GameObject objectParent;
    public GameObject connectObject, regObject;

    private void Awake()
    {
        chekReg();      
    }

    void chekReg()
    {
        
            connectObject.SetActive(false);
            regObject.SetActive(false);
            objectParent.SetActive(true);
    }

    public void InputNameChange()
    {
        if (loginInpud.text.Length >= 2)
        {
            entercrBut.SetActive(true);
        }
        else
        {
            entercrBut.SetActive(false);
        }
    }

    public void CreateUserName()
    {
        PhotonNetwork.playerName = loginInpud.text;
        
        connectObject.SetActive(true);
        objectParent.SetActive(false);

    }

   
}
