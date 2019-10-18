using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class GenPole2 : Photon.MonoBehaviour
{
    public GameObject eKletka;
    public PhotonView photonV;
	private GameObject [,] Pole;// Массив поля
	private int Xop = 29;// размеры
    private int Yop = 14;// -.-

    public int Random_vs_Order = 1;// Заполнение поля рандомно или по порядку.
    public int PlayerNum = 0;//
    public static int ModeGen = 4;
    
    private void CreatePole()//отрисовка поля по заданым значениям
    {
        Vector3 StartPoze = transform.position;// берет позиции стартовые
		float XX = StartPoze.x;//передает стартовую позицию по иксу
		float YY = StartPoze.y;	// тожесамое по игрику
		Pole = new GameObject[Xop, Yop];// игрвой обьект с задаными иксом и игриком

		for(int Y = 0; Y < Yop; Y++)//проход создания по игрику
        {
			for(int X = 0; X < Xop; X++)// по иксу
            {
				Pole [X, Y] = Instantiate (eKletka);//создает заданый обьект на поле в текущих координатах
				Pole [X, Y].GetComponent<chanks> ().Index = 0;//присваевает обьекту индекс анимации(спрайт)
				Pole [X, Y].transform.position = new Vector3 (XX, YY, StartPoze.z);//штука которая делает что то важное с позициями 
                XX++;// дает знать что проход все ок, и отступает от старт позиции
			}
			XX = StartPoze.x;//когда строка закончена возвращает на стартовый икс
			YY--;//опускает вниз строителя
		}
	}

	private void Start ()
    {
        if (photonV.isMine)
        {
            if (PhotonNetwork.isMasterClient)
            {
                CreatePole();// при старте создать поле 
            }
        }
        //ScorePl = GameObject.Find("Score");       
    }
	
	private void Update ()
    {
        if (photonView.isMine)
        {
           // ScorePl.GetComponent<Text>().text = score.ToString();// Вывод очков игрока на экран 
        }
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }

    [PunRPC]
    void ScoreManager(int idpl)
    {
        PlayerNum = idpl;

        if (Random_vs_Order == 1)
        {
            CykaBliati();
        }
        else
        {
            This_is_Random();
        }
    }

    void CykaBliati()
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
                                Pole[X, Y].GetComponent<chanks>().Index = 1;// дать ей спрайт по индексу
                                PlayerNum = 0;//сказать что выполнено 
                                
                                //score++;//дать очков игроку
                                goto  default;//раз все заебись то остальное можно пропустить
                            }
                            XX++;//может пригодится как и другие штуки ниже от генерации
                        }
                        XX = StartPoze.x;
                        YY--;
                    }
                    
                    break;
                case 2:// точно также
                    for (int Y = 0; Y < Yop; Y++)//
                    {

                        for (int X = 0; X < Xop; X++)//
                        {

                            Pole[X, Y].transform.position = new Vector3(XX, YY, StartPoze.z);//
                            
                            Idexx = Pole[X, Y].GetComponent<chanks>().Index;//

                            if (Idexx == 0)//
                            {
                                Pole[X, Y].GetComponent<chanks>().Index = 2;//
                                PlayerNum = 0;//
                                
                                //score2++;//
                                goto default;//
                            }
                            XX++;//
                        }
                        XX = StartPoze.x;//
                        YY--;//
                    }
                    
                    break;
                case 3:
                    for (int Y = 0; Y < Yop; Y++)//
                    {

                        for (int X = 0; X < Xop; X++)//
                        {

                            Pole[X, Y].transform.position = new Vector3(XX, YY, StartPoze.z);//
                            
                            Idexx = Pole[X, Y].GetComponent<chanks>().Index;//

                            if (Idexx == 0)//
                            {
                                Pole[X, Y].GetComponent<chanks>().Index = 3;//
                                PlayerNum = 0;//
                                
                                //score3++;//
                                goto default;//
                            }
                            XX++;//
                        }
                        XX = StartPoze.x;//
                        YY--;//
                    }
                    
                    break;
                case 4://
                    for (int Y = 0; Y < Yop; Y++)
                    {

                        for (int X = 0; X < Xop; X++)
                        {

                            Pole[X, Y].transform.position = new Vector3(XX, YY, StartPoze.z);
                            
                            Idexx = Pole[X, Y].GetComponent<chanks>().Index;

                            if (Idexx == 0)
                            {
                                Pole[X, Y].GetComponent<chanks>().Index = 4;
                                PlayerNum = 0;
                                
                                //score4++;
                                goto default;
                            }
                            XX++;
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

    void This_is_Random()// случаность
    {

        if (PlayerNum != 0)//если не пуста
        {
            
            int Y, X, IdeR;// создать новые переменные

            switch (PlayerNum)// понятно
            {

                case 1://для первого игрока
                    int qw = 0;//сдеано для управления
                    for(;qw==0 ;)// для виду
                    {
                        
                        X = Random.RandomRange(0, Xop);//дать рандомное число от нуля до заданного значения икса
                        Y = Random.RandomRange(0, Yop);// тоже самое с игриком
                        IdeR = Pole[X, Y].GetComponent<chanks>().Index;// передать индекс клетки по этим координатам
                        if (IdeR == 0)//проверить ее на пустоту и если ровна
                        {
                            Pole[X, Y].GetComponent<chanks>().Index = 1;//задать спрайт игрока
                            PlayerNum = 0;//сказать что все заебись
                            //score++;//дать очкО игроку
                            goto default;//пропустить говнокод
                        }
                        else//если не прошло то попробовать но новым координатам (пустить кейс по новой)
                        {
                            goto case 1;//
                        }
                    }

                    break;
                case 2:
                   

                    X = Random.RandomRange(0, Xop);
                    Y = Random.RandomRange(0, Yop);
                    IdeR = Pole[X, Y].GetComponent<chanks>().Index;
                    if (IdeR == 0)
                    {

                        Pole[X, Y].GetComponent<chanks>().Index = 2;
                        PlayerNum = 0;
                        //GetComponent<Global>().score2++;
                        //score2++;
                        goto default;


                    }
                    else
                    {
                        goto case 2;
                    }
                    break;
                case 3:
                    int er = 0;
                    for (; er == 0;)
                    {
                        
                        X = Random.RandomRange(0, Xop);
                        Y = Random.RandomRange(0, Yop);
                        IdeR = Pole[X, Y].GetComponent<chanks>().Index;
                        if (IdeR == 0)
                        {
                            Pole[X, Y].GetComponent<chanks>().Index = 3;
                            PlayerNum = 0;
                            //score3++;
                            goto default;
                        }
                        else
                        {
                            goto case 3;
                        }
                    }

                    break;
                case 4:
                    int rt = 0;
                    for (; rt == 0;)
                    {
                        
                        X = Random.RandomRange(0, Xop);
                        Y = Random.RandomRange(0, Yop);
                        IdeR = Pole[X, Y].GetComponent<chanks>().Index;
                        if (IdeR == 0)
                        {

                            Pole[X, Y].GetComponent<chanks>().Index = 4;
                            PlayerNum = 0;
                            
                            //score4++;
                            goto default;

                        }
                        else
                        {
                            goto case 4;
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

