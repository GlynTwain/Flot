using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscGe : MonoBehaviour {

    int end = 0;


	public void EscBut()
    {
        gameObject.SetActive(false);
        end = 0;
    }


    public void EscBu2()
    {
        gameObject.SetActive(true);
        //end!=0

    }

    void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            gameObject.SetActive(true);
            end = 1;
        }
	}
}
