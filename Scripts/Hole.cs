using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    //Script duoc su dung boi object Hole
    private GameObject gameController;
    public bool HoleSound = false;

    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
	

    private void OnTriggerEnter2D(Collider2D collision)//Nguoi choi roi xuong
    {
        if (gameController.GetComponent<GameCotroller>().isNextLV == false && gameController.GetComponent<GameCotroller>().isGameOver == false)//Neu chua GameOver va chua qua man
        {
            HoleSound = true;//Am bao khi roi xuong
            gameController.GetComponent<GameCotroller>().EndGame();//Game over
            Time.timeScale = 0;//Dung Game
        }
    }
}
