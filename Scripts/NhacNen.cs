using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhacNen : MonoBehaviour {
   
    //Script duoc su dung boi object nhacNen
    public AudioSource BMusic;
    public float amLuong = 0.2f;

	void Start() {
        DontDestroyOnLoad(transform.gameObject);//khong pha huy object nay khi chuyen scene, nhac nen se tiep tuc chay xuyen suot game
        BMusic = gameObject.GetComponent<AudioSource>();//Lay AudioSource tu object gan script nay
        BMusic.volume = amLuong;//dieu chinh am luong
    }


    public void PlayMusic()
    {
        if (BMusic.isPlaying) return;//neu nhac dang chay thi khong lam gi ca
        BMusic.Play();//chay nhac
    }
}
