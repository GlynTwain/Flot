using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButRoom : Photon.MonoBehaviour {

    public string nameroom;

	public void press()
    {
        PhotonNetwork.JoinRoom(nameroom);
    }
}
