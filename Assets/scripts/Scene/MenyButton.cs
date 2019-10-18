using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenyButton : MonoBehaviour {

    public GameObject suppInf;
    private bool OnSup = true;

    public void GoSettings()
    {
        Application.LoadLevel(4);
    }

    public void ExtGame()
    {
        Application.Quit() ;
    }

    public void SelectMode()
    {
        Application.LoadLevel(5);
    }

    public void SupButton()
    {
        if (OnSup)
        {
            suppInf.SetActive(false);
        }
        OnSup = false;
    }
}
