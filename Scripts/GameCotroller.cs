using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCotroller : MonoBehaviour {

    //Script nay duoc su dung boi object GameCotroller
    public bool isGameOver, isNextLV;
    private AudioSource audioSource;
    public AudioClip NextLVClip, RoiHo, NhacBomNo;
    private GameObject player, Bomb, Hole, nhacNen;
    public Text BombTime;
    private int Btimes;
    public GameObject GameOverPanel, defusingPanel, nextLVImage, ClearImage;

    void Start () {
        isGameOver = false;//Van chua game over
        isNextLV = false;//chua chuyen man duoc
        audioSource = gameObject.GetComponent<AudioSource>();//Chua am thanh de chay
        player = GameObject.FindGameObjectWithTag("Player");//Ham de goi ben scripts Player
        Bomb = GameObject.FindGameObjectWithTag("Bom");//Ham de goi ben scripts BomController
        Hole = GameObject.FindGameObjectWithTag("Hole");//Ham de goi ben scripts Hole
        nhacNen = GameObject.FindGameObjectWithTag("NhacNen");//Goi ham chay nhac nen
        Btimes = (int)Bomb.GetComponent<BomController>().ExplorTime;//Bien chua thoi gian bom
        Time.timeScale = 1;//Thoi gian chay
    }
	
	void Update () {

        if (!isGameOver && !isNextLV)//Neu dang choi
        {
            int t = Btimes - (int)Time.timeSinceLevelLoad; //Dem thoi gian bom 
            BombTime.text = t.ToString();//hien text len man hinh
        }

        if (Input.GetKeyDown(KeyCode.Return) && isNextLV)//Go bom thanh cong, bam Enter de qua man
        {
            int i = SceneManager.GetActiveScene().buildIndex;//Lay so index cua scene hien tai
            if (i < 7)//Neu chua phai man cuoi ( man 6 )
            {
                SceneManager.LoadScene(i + 1, LoadSceneMode.Single);//Load Scene ke tiep
            }
            else
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);//Neu da la man cuoi thi quay ve menu
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && isGameOver)//Bom no, Game Over, nhan Enter de tiep
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);//Quay lai man huong dan
            nhacNen.GetComponent<NhacNen>().PlayMusic();//Chay nhac nen
        }

        if(Input.GetKeyDown(KeyCode.F11) && !isNextLV && !isGameOver)//Hack :))
        {
            Bomb.GetComponent<BomController>().BomHoatDong = false;
            NextLV();
        }
    }

    public void EndGame()//Bom no va game ket thuc
    {
        nhacNen.GetComponent<NhacNen>().BMusic.Stop();
        player.GetComponent<Player>().diChuyen = false;//player khong the di chuyen nua
        isGameOver = true;//Game over
        if (Hole.GetComponent<Hole>().HoleSound)//Phat ra am bao khi bom no hoac nguoi choi bi roi xuong
        {
            audioSource.clip = RoiHo;//Am bao khi roi ho
        }
        else
        {
            audioSource.clip = NhacBomNo;//Am bao khi bom no
        }
        audioSource.Play();
        defusingPanel.SetActive(false);//khong go bom kip
        GameOverPanel.SetActive(true);//Hien thi thong bao GameOver
        Destroy(BombTime);//ngung dem thoi gian bom
    }
    public void NextLV()
    {
        isNextLV = true;//Qua man
        player.GetComponent<Player>().diChuyen = false;//player khong the di chuyen nua
        defusingPanel.SetActive(false);//go bom thanh cong, tat panel defusing
        audioSource.clip = NextLVClip;
        audioSource.volume = 1;//am luong
        audioSource.Play();
        nextLVImage.SetActive(true);//hien hinh anh thong bao xong man
        if (SceneManager.GetActiveScene().buildIndex == 7)//neu da la man cuoi
        {
            ClearImage.SetActive(true);//hien hinh anh thong bao hoan thanh game
            nhacNen.GetComponent<NhacNen>().BMusic.Stop();
        }

    }
}
