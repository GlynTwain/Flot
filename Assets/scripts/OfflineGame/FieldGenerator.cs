using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FieldGenerator : MonoBehaviour {

    #region ======================================================== DATA ===================================

    [SerializeField] private int Xop = 0;//
    [SerializeField] private int Yop = 0;//

    public static int ModeGen = 4;// размеры поля
    private GameObject[,] Pole;//
    public GameObject eKletka;//
    public Text ScoreTextUI; //сюда подключать текст
    private Transform PoleFather;
    public int score = 0;
   
    public static int Random_vs_Order = 1;//
    public int PlayerNum = 0;//

    #endregion

    private void CreatePole()//отрисовка поля по заданым значениям
    {
        switch (ModeGen)
        {

            case 1:
                // transform.position = Vector3.(-699.3f, 382.5f);
                Xop = 10;
                Yop = 10;

                break;
            case 2:
                //gameObject.transform.position = new Vector3(-699.3f, 382.5f, 75);
                Xop = 20;
                Yop = 10;
                break;
            case 3:
                //transform.position = new Vector3(-713, 397);
                Xop = 30;
                Yop = 15;
                break;
            case 4:
                //transform.position = new Vector3(-699.3,382.5);
                Xop = 29;
                Yop = 14;
                break;

        }

        Vector3 StartPoze = transform.position;// берет позиции стартовые
        float XX = StartPoze.x;//передает стартовую позицию по иксу
        float YY = StartPoze.y; // тожесамое по игрику
        Pole = new GameObject[Xop, Yop];// игрвой обьект с задаными иксом и игриком
        for (int Y = 0; Y < Yop; Y++)//проход создания по игрику
        {
            for (int X = 0; X < Xop; X++)// по иксу
            {
                Pole[X, Y] = Instantiate(eKletka);//создает заданый обьект на поле в текущих координатах
                Pole[X, Y].GetComponent<chanks>().Index = 0;//присваевает обьекту индекс анимации(спрайт)
                Pole[X, Y].transform.position = new Vector3(XX, YY, StartPoze.z);//штука которая делает что то важное с позициями 
                Pole[X, Y].transform.SetParent(this.gameObject.transform);
                XX++;// дает знать что проход все ок, и отступает от старт позиции
            }
            XX = StartPoze.x;//когда строка закончена возвращает на стартовый икс
            YY--;//опускает вниз строителя
        }
    }

    private void Awake()
    {
        CreatePole();// при старте
    }

    private void Update()
    {
        ScoreTextUI.text = score.ToString();

        if (Random_vs_Order == 1 && PlayerNum==1)
        {
            CykaBliati();
        }
        else
        {
            This_is_Random();
        }
    }

    private void CykaBliati()
    {
        if (PlayerNum != 0)//если переменная не пуста
        {
            Vector3 StartPoze = transform.position;//направить на стартовую позицию
            float XX = StartPoze.x;//
            float YY = StartPoze.y;//
            int Idexx = 0;//хз

            switch (PlayerNum)// смотреть на значение и выбирать кейсы
            {
                case 1://
                    for (int Y = 0; Y < Yop; Y++)//проход по игрику
                    {
                        for (int X = 0; X < Xop; X++)//иксу
                        {
                            Pole[X, Y].transform.position = new Vector3(XX, YY, StartPoze.z);//аналогия генерации

                            Idexx = Pole[X, Y].GetComponent<chanks>().Index;//узнать индекс клетки на которую попал

                            if (Idexx == 0)// если пуста то заполнить
                            {
                                Pole[X, Y].GetComponent<chanks>().Index = Random.Range(1,5);// дать ей спрайт по индексу
                                PlayerNum = 0;//сказать что выполнено 

                                score++;//дать очков игроку
                                goto default;//раз все заебись то остальное можно пропустить
                            }
                            XX++;//может пригодится как и другие штуки ниже от генерации
                        }
                        XX = StartPoze.x;
                        YY--;
                    }
                    break;
                
                default://предохрантель от кривых рук, дополнительно обнуляет переменную

                    PlayerNum = 0;
                    break;

            }

        }

    }// по порядку, по структуре напоминает создание

    private void This_is_Random()// случаность
    {
        if (PlayerNum != 0)//если не пуста
        {
            int Y, X, IdeR;// создать новые переменные
            switch (PlayerNum)// понятно
            {
                case 1://для первого игрока
                    int qw = 0;//сдеано для управления
                    for (; qw == 0;)// для виду
                    {
                        X = Random.RandomRange(0, Xop);//дать рандомное число от нуля до заданного значения икса
                        Y = Random.RandomRange(0, Yop);// тоже самое с игриком
                        IdeR = Pole[X, Y].GetComponent<chanks>().Index;// передать индекс клетки по этим координатам
                        if (IdeR == 0)//проверить ее на пустоту и если ровна
                        {
                            Pole[X, Y].GetComponent<chanks>().Index = Random.Range(1, 5);//задать спрайт игрока
                            PlayerNum = 0;//сказать что все заебись
                            score++;//дать очко игроку
                            goto default;//пропустить говнокод
                        }
                        else//если не прошло то попробовать но новым координатам (пустить кейс по новой)
                        {
                            goto case 1;//
                        }
                    }
                    break;
                
                default:
                    PlayerNum = 0; //это предохранитель от кривых рук, на всякий сучай обнуляет переменную 
                    break;
            }
        }
    }// случайные клетки по случ координатам
}
