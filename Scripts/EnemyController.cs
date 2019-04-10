using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    //Script duoc su dung boi prefeb Ke dich
    public GameObject DiemDiChuyen1, DiemDiChuyen2;
    public float tocDo = 3;
    Vector3 DiemDen;
    private Animator anim;
    private GameObject player, gameController;
    private bool diChuyen = true, attack = false;
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();//Bien chua animation cho object duoc gan script nay
        transform.position = DiemDiChuyen1.transform.position;//bat dau vi tri ke dich voi toa do cua diem di chuyen 1
        DiemDen = DiemDiChuyen2.transform.position;//diem den la toa do cua diem di chuyen 2
        player = GameObject.FindGameObjectWithTag("Player");//Ham de goi ben scripts Player
        gameController = GameObject.FindGameObjectWithTag("GameController");//Dung de Goi scripts tu game object co tag GameController
    }

   
    void Update()
    {
        anim.SetFloat("Speed", 1);//ke dich di chuyen
        anim.SetBool("Attack", attack);//ke dich chua tan cong
       
    }
    private void FixedUpdate()
    {
        if (diChuyen)
        {
            transform.position = Vector2.MoveTowards(transform.position, DiemDen, tocDo * Time.deltaTime);//di tu diem di chuyen 1 den 2
            if (Vector2.Distance(transform.position, DiemDen) <= 0.5f)//Neu den noi
            {
                if (DiemDen == DiemDiChuyen1.transform.position)//Neu diem den la diem di chuyen 1
                {
                    DiemDen = DiemDiChuyen2.transform.position;//thay doi diem den la diem di chuyen 2
                    Flip();
                }
                else//nguoc lai neu diem den la diem di chuyen 2
                {
                    DiemDen = DiemDiChuyen1.transform.position;//thay doi diem den la diem di chuyen 1
                    Flip();
                }
            }
            //Nhu vay se di chuyen qua lai giua 2 diem
        }

    }

    public void Flip() // Chuyen huong nhan vat
    {
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == player.GetComponent<Collider2D>() && !gameController.GetComponent<GameCotroller>().isGameOver && !gameController.GetComponent<GameCotroller>().isNextLV)//Neu nguoi choi dung phai ke dich
        {
            diChuyen = false;//ke dich ngung di chuyen
            attack = true;//ke dich tan cong
            gameController.GetComponent<GameCotroller>().EndGame();//gameover
            player.GetComponent<Player>().anim.SetBool("Dead", true);//bat animation Dead cho player
        }
    }
}
