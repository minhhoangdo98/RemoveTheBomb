using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBomb : MonoBehaviour {

    //Script duoc su dung boi prefab FakeBomb
    private GameObject gameController, Bomb, player;
    public GameObject Explor;

    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController");//Dung de Goi scripts tu game object co tag GameController
        Bomb = GameObject.FindGameObjectWithTag("Bom");//Dung de Goi scripts tu game object co tag Bom
        player = GameObject.FindGameObjectWithTag("Player");//Dung de Goi scripts tu game object co tag Player
    }
	

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);//Neu nguoi choi cham vao qua bom nay thi se phat no
    }

    private void OnDestroy()
    {
        if (Bomb != null && gameController != null)//Neu bom that van con va da co gameController
        {
            if (gameController.GetComponent<GameCotroller>().isNextLV == false && Bomb.GetComponent<BomController>().BomHoatDong && gameController.GetComponent<GameCotroller>().isGameOver == false)//Neu bom that con hoat dong, chua gameover va chua qua man
            {
                GameObject Exp = Instantiate(Explor, transform.position, Quaternion.identity) as GameObject;//Tao ra mot vu no
                Destroy(Exp, 1.4f);
                Bomb.GetComponent<BomController>().BomHoatDong = false;//bom that ngung hoat dong
                gameController.GetComponent<GameCotroller>().EndGame();//Gameover
                player.GetComponent<Player>().anim.SetBool("Dead", true);//bat animation Dead cho player
            }
        }
    }
}
