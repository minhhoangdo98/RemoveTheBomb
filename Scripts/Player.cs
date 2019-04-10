using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    //Script nay duoc su dung boi object Player
    public float speed = 150f, maxspeed = 3, jumpPow = 550f;
    public bool grounded = true, faceright = true, doubleJump = false;
    public Rigidbody2D r2;
    public Animator anim;
    public AudioClip Nhay;
    private AudioSource audioSource;
    public bool diChuyen;


	void Start () {
        r2 = gameObject.GetComponent<Rigidbody2D>();//Lay nhan vat
        anim = gameObject.GetComponent<Animator>();//Bien chua animation cho Player
        audioSource = gameObject.GetComponent<AudioSource>();//Chua am thanh de chay
        audioSource.clip = Nhay;//am thanh nhay
        diChuyen = true;//co the di chuyen
	}
	

	void Update () {
        anim.SetBool("Grounded", grounded);//animation khi dung yen tren mat dat (grounded = true)
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x)); // Mathf.abs: tra ve gia tri duong ; r2.velocity.x: toc do hien tai, animation khi chay

        if(Input.GetKeyDown(KeyCode.Space) && diChuyen) // neu nut an xuong cua nguoi choi la Space va dang cho phep di chuyen (diChuyen = true)
        {
            gameObject.GetComponent<GroundCheck>();//Goi ham kiem tra xem Player co dang dung tren mat dat hay khong
            if (grounded)//neu dang dung tren mat dat
            {
                grounded = false;//cho grounded = false tuc la nguoi choi se nhay len khong
                doubleJump = true;//co the nhay tiep lan 2
                audioSource.Play();//Play am thanh khi nhay
                r2.AddForce(Vector2.up * jumpPow);//thay doi vi tri nhan vat len tren dua vao jumpPow
            }
            else//Nguoc lai, Neu khong dung tren mat dat
            {
                if (doubleJump)//neu chua nhay lan 2
                {
                    doubleJump = false;//nhay tiep lan 2 va khong the nhay them nua
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    audioSource.Play();
                    r2.AddForce(Vector2.up * jumpPow * 0.8f);
                }
            }
        }
	}

    void FixedUpdate()
    {
        if (diChuyen)//neu cho phep di chuyen (diChuyen = true)
        {
            float h = Input.GetAxis("Horizontal");//Lay thong tin nut bam la nut mui ten (Phai: 1, Trai: -1)
            r2.AddForce(Vector2.right * speed * h);//Thay doi vi tri nhan vat dua vao speed va h

            //Ham gioi han toc do di chuyen
            if (r2.velocity.x > maxspeed) //Gioi han toc do di ve ben phai
                r2.velocity = new Vector2(maxspeed, r2.velocity.y);
            if (r2.velocity.x < -maxspeed)// Gioi han toc do di ve ben trai
                r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

            if (h > 0 && !faceright)//Neu h > 0 tuc la ben phai va player dang quay ve ben trai
            {
                Flip();//Goi ham dao chieu
            }
            if (h < 0 && faceright)//Neu h < 0 tuc la ben trai va player dang quay ve ben phai
            {
                Flip();
            }

            if (grounded)
            {
                r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
            }
        }
    }

    public void Flip() // Chuyen huong nhan vat
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;

    }
}
