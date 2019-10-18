using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESC : MonoBehaviour {

	public void GoMeny()
    {

        Application.LoadLevel(0);

    }

    public void GoDesctop()
    {
        Application.Quit();
    }

}
