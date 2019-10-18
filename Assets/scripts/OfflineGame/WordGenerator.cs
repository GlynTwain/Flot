using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WordGenerator : MonoBehaviour {

    public Text OutputWordText;// Суда сувать Текстовой Обьект
    public string slovo = ""; // А Это показывать пезду
    public InputField vvedennoe; // Тут подключается поле ввода 
    public string veden;// сюда выводятся введеные из поля
    public static int ModeO = 1;
    private FieldGenerator fieldGenerator;
    public Text speed;

    public void Uiu()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.KeypadEnter)) // кнопки для нажатий
        {
            //veden = vvedennoe.text;// перекидываем введеное с поля в переменную для удобства
            if (String.CompareOrdinal(vvedennoe.text, slovo) == 0)//сравниваем две строки
            {
                vvedennoe.text = " ";// очищаем поле ввода
                fieldGenerator.PlayerNum = 1;//обращаюсь к переменной в этом обьекте, на нее передается номер игрока
                CreatWord();
                vvedennoe.ActivateInputField();

            }
        }
    }

    private void Start()
    {
        fieldGenerator = GameObject.Find("FieldGenerator").GetComponent<FieldGenerator>();
        CreatWord();
    }

    private void Update()//выполняется каждый фрейм
    {
        Uiu();//
        OutputWordText.text = slovo;
    }

    private void CreatWord()
    {
        switch (ModeO)
        {

            case 1:

                System.Random e = new System.Random();//просим систему зарандомить значение
                string[] string_array1 = File.ReadAllLines("C:/Games/Flot/easy.txt");// регаем строчный массив и присваевае ему слова из файла
                slovo = string_array1[e.Next(0, string_array1.Length)];

                break;

            case 2:

                System.Random n = new System.Random();//просим систему зарандомить значение
                string[] string_array2 = File.ReadAllLines("C:/Games/Flot/normally.txt");// регаем строчный массив и присваевае ему слова из файла
                slovo = string_array2[n.Next(0, string_array2.Length)];

                break;

            case 3:

                System.Random d = new System.Random();//просим систему зарандомить значение
                string[] string_array3 = File.ReadAllLines("C:/Games/Flot/difficultly.txt");// регаем строчный массив и присваевае ему слова из файла
                slovo = string_array3[d.Next(0, string_array3.Length)];

                break;

            case 4:

                System.Random r = new System.Random();//просим систему зарандомить значение
                string[] string_array = File.ReadAllLines("C:/Games/Flot/rand.txt");// регаем строчный массив и присваевае ему слова из файла
                slovo = string_array[r.Next(0, string_array.Length)];

                break;

        }
    }
}
