using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{

	public Rigidbody rigidbody;
	public Text speedText;
	private double speed;

	private void Speed(){
		speed = (rigidbody.velocity.magnitude * 2.237 * Time.deltaTime) * 100;
		if(speed < 1){
			speedText.text = "0";
		}
		else{
			speedText.text = speed.ToString("#");
		}
	}

    private void FixedUpdate()
    {
        Speed();
    }
}
