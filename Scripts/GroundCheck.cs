using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    //Script nay duoc su dung boi script Player
    private GameObject obj;


	void Start () {
        obj = gameObject;
	}
	

    public void OnCollisionEnter2D( Collision2D collider)//Player cham vao mat dat
    {
        obj.GetComponent<Player>().grounded = true;
    }
    public void OnCollisionStay2D(Collision2D collider)//Player dung o mat dat
    {
        obj.GetComponent<Player>().grounded = true;
    }
    public void OnCollisionExit2D(Collision2D collider)//Player roi khoi mat dat
    {
        obj.GetComponent<Player>().grounded = false;
    }
}
