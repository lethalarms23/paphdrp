using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDSpeed : Photon.MonoBehaviour
{
    public Rigidbody rigidCar;
    public float carVelocity;
    public GameObject text;
    public Transform ponteiro;
    public Text speed;
    public float z = 0;
    public PhotonView photonView;

    public void Start() {
        z = ponteiro.eulerAngles.z;
        speed = text.GetComponent<Text>();
    }

    public void Velocity(){
        carVelocity = (rigidCar.velocity.magnitude * 2.237f * Time.deltaTime) * 100;
		if(carVelocity < 1){
			speed.text = "0";
		}
		else{
			speed.text = carVelocity.ToString("#");
		}
    }

    public void ponteiroFunc(){
    	z =  113 + (-carVelocity);
    	Vector3 steer = new Vector3(0,0,z);
        ponteiro.eulerAngles = steer;
    }

    public void FixedUpdate() {
        if(this.photonView.isMine == true){
            Velocity();
            ponteiroFunc();
        }
        else{
            return;
        }
    }
}
