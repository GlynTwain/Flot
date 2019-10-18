using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroScene : MonoBehaviour {

    public int i;
    private float qw = 2;
	
	private void Update ()
    {
        qw -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape)||qw<=0)
        {
            Application.LoadLevel(i);
        }
	}
}
