using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomController : MonoBehaviour {

    //Script nay duoc su dung boi object Bom
    public float ExplorTime = 30;
    public GameObject Explor;
    GameObject obj;
    public bool BomHoatDong;
    private GameObject gameController;
    
	void Start () {
        obj = gameObject;//Gan obj la bom
        Destroy(obj, ExplorTime);//Xoa Bom sau khoang thoi gian ExplorTime
        BomHoatDong = true;//Bom dang hoat dong
        gameController = GameObject.FindGameObjectWithTag("GameController");//Goi ham de chay GameController
    }
	

    private void OnDestroy()
    {
        if (gameController != null)
        {
            if (BomHoatDong && gameController.GetComponent<GameCotroller>().isGameOver == false)//Neu bom dang hoat dong va chua gameover
            {
                GameObject Exp = Instantiate(Explor, transform.position, Quaternion.identity) as GameObject;//Bom phat no
                Destroy(Exp, 1.4f);
                gameController.GetComponent<GameCotroller>().EndGame();//gameover
            }
        }
   
    }

    private void OnTriggerEnter2D(Collider2D collision)//Nguoi choi bat dau go bom
    {
        gameController.GetComponent<GameCotroller>().defusingPanel.SetActive(true);//hien panel defusing de go bom
    }
}
