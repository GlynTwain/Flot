using UnityEngine;
using UnityEngine.UI;
public class ScoreAdder : MonoBehaviour {

    private PhotonView _photonV;

    public  void PV()
    {
        _photonV = this.gameObject.GetComponent<PhotonView>();
        Component tet = this.gameObject.GetComponent<Text>();
        _photonV.ObservedComponents.Add(tet);
    }
}
