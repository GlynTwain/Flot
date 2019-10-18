using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Reggistration : MonoBehaviour {

    public InputField pas1;
    public InputField pas2;
    public Text verInf;

	public void Verify()
    {

        if (System.String.CompareOrdinal(pas1.text, pas2.text) == 0)
        {
            verInf.text = "С паролем все хорошо"; 
        }
        else
        {
            verInf.text = "Пароль не совпадает";
        }
    }
}
