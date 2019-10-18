using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class toggle : MonoBehaviour {

    public void SelMode(int i)
    {
        FieldGenerator.ModeGen = i;
    }

    public void easy(int i)
    {
        WordGenerator.ModeO = i;
    }

    public void randomchacnkpole(int i )
    {
        FieldGenerator.Random_vs_Order = i;
    }

}
