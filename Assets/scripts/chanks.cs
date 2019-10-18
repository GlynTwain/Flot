using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chanks : Photon.MonoBehaviour
{
	public Sprite[] imgs; // массив с цветами - обьектами
	public int Index = 0; // задавать цвет (знаечние от 0 до 4)
    public PhotonView photonV;

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(PhotonNetwork.isMasterClient & stream.isWriting)
        {
            stream.Serialize(ref Index);
        }

        if (!PhotonNetwork.isMasterClient)
        {
            Index = (int)stream.ReceiveNext();
        }
    }


    void ChangeImg ()
	{
		if (imgs.Length > Index) 
		{
			GetComponent<SpriteRenderer> ().sprite = imgs [Index];// меняет цвет спрайта
		}
	}

	void Start ()
    {
		ChangeImg ();// При старте
	}


	void Update ()
    {
		ChangeImg ();// Для обновления во время игры
	}
}
