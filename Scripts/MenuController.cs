using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    private GameObject nhacNen;

    void Start () {
        nhacNen = GameObject.FindGameObjectWithTag("NhacNen");//Goi ham chay nhac nen
    }
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))//Bam Enter de choi
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
            nhacNen.GetComponent<NhacNen>().PlayMusic();//Chay nhac nen
        }
    }
}
