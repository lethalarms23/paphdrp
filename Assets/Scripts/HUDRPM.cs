using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDRPM : MonoBehaviour
{
    public WheelCollider rearDriverW;
    public Transform ponteiro;
    public float z = 0;

    public void Start() {
        z = ponteiro.eulerAngles.z;
    }

    public void FixedUpdate() {
        if(rearDriverW.rpm < 1){
            z =  80 + (rearDriverW.rpm / 10);
        }
        else if(rearDriverW.rpm > -1){
            z =  80 - (rearDriverW.rpm / 10);
        }
    	Vector3 steer = new Vector3(0,0,z);
        ponteiro.eulerAngles = steer;
    }   
}
