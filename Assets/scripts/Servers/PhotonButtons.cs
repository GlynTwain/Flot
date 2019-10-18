using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhotonButtons : MonoBehaviour {
    #region ===================================   FIELDS

    public InputField loginInput, passwordInput, nameRoomInput, passRoomInput;

    public Text inf;

    public PhotonHolder phHolder;

    #endregion

    #region ==================================     METODS

    public void OnClickCreateRoom()
    {
        phHolder.OnClickCreateRoom();
    }

    public void OnClickJoinRoom()
    {
        phHolder.OnClickJoinRoom();
    }

    private void OnJoinedRoom()
    {
        phHolder.MoveScene();
    }

    public void OnClickLogin()
    {

    }



    #endregion
}
