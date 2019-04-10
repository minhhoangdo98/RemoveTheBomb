using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour {

    //Script nay duoc su dung boi prefab Buff_Speed va Buff_Jump
    private GameObject Player;
    public int buff;
    public float speedBuff = 100f, jumPowBuff = 250f;
	
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");//Dung de Goi scripts tu game object co tag Player
    }
	
	
    private void OnTriggerEnter2D(Collider2D collision)//khi nguoi choi an mon nay
    {
        if(buff == 1)//buff toc do
        {
            Player.GetComponent<Player>().speed += speedBuff;
            Player.GetComponent<Player>().maxspeed += 1;
            Destroy(gameObject);
        }
        if(buff == 2)//buff luc nhay
        {
            Player.GetComponent<Player>().jumpPow += jumPowBuff;
            Destroy(gameObject);
        }
    }
}
