using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{

	public Rigidbody rigidCar;
	public Text speedText;
	private float speed;

	private void SpeedCar(){
		speed = (rigidCar.velocity.magnitude * 2.237f * Time.deltaTime) * 100;
		if(speed < 1){
			speedText.text = "0";
		}
		else{
			speedText.text = speed.ToString("#");
		}
	}

    private void FixedUpdate()
    {
        SpeedCar();
    }


}
