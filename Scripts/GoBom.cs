using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoBom : MonoBehaviour {

    //Script nay duoc su dung boi script BomController
    private GameObject gameController, Bomb, player;
    private AudioSource sound;
    public Text nB1, nB2, nB3, nB4, nB5;
    public int min, max;
    private int i = 1;

    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController");//Dung de Goi scripts tu game object co tag GameController
        Bomb = GameObject.FindGameObjectWithTag("Bom");//Dung de Goi scripts tu game object co tag Bom
        player = GameObject.FindGameObjectWithTag("Player");//Dung de Goi scripts tu game object co tag Player
        player.GetComponent<Player>().diChuyen = false;//Ngung di chuyen trong khi go bom
        sound = gameObject.GetComponent<AudioSource>();//am bao khi nhap dung so
        nB1.text = Random.Range(min, max).ToString();//lay so ngau nhien lam mat ma go bom, nB1 la mat ma thu 1 
        nB2.text = Random.Range(min, max).ToString();
        nB3.text = Random.Range(min, max).ToString();
        nB4.text = Random.Range(min, max).ToString();
        nB5.text = Random.Range(min, max).ToString();
    }
	

	void Update () {
        string s;
        if (!gameController.GetComponent<GameCotroller>().isNextLV && !gameController.GetComponent<GameCotroller>().isGameOver)//Neu chua xong man va chua gameover
        {
                switch (i)//kiem tra xem dang nhap den mat ma thu may
                {
                    case 1://nhap mat ma thu 1
                        s = Input.inputString;//lay ki tu vua nhap
                        if (s == nB1.text.ToString())//neu ki tu vua nhap dung voi mat ma
                        {
                            i++;//tang i tuc la nhap mat ma thu tiep theo
                            sound.Play();//am bao nhap dung
                            nB1.text = "";//xoa text mat ma nay
                        }
                        break;
                    case 2://nhap mat ma thu 2
                        s = Input.inputString;
                        if (s == nB2.text.ToString())
                        {
                            i++;
                            sound.Play();
                            nB2.text = "";
                        }
                        break;
                    case 3://nhap mat ma thu 3
                        s = Input.inputString;
                        if (s == nB3.text.ToString())
                        {
                            i++;
                            sound.Play();
                            nB3.text = "";
                        }
                        break;
                    case 4://nhap mat ma thu 4
                        s = Input.inputString;
                        if (s == nB4.text.ToString())
                        {
                            i++;
                            sound.Play();
                            nB4.text = "";
                        }
                        break;
                    case 5://nhap mat ma thu 5
                        s = Input.inputString;
                        if (s == nB5.text.ToString())
                        {
                            sound.Play();
                            Bomb.GetComponent<BomController>().BomHoatDong = false;//Bom khong hoat dong nua
                            Destroy(Bomb);//pha huy bom
                            gameController.GetComponent<GameCotroller>().NextLV();//Chuyen man choi tiep theo
                        }
                        break;
                }
             
        }
	}
}
