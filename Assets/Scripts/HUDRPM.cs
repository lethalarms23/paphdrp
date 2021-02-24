using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDRPM : Photon.MonoBehaviour
{
    public WheelCollider rearDriverW;
    public GameObject ponteiroRpm;
    public Transform ponteiro;
    public float z = 0;
    public PhotonView photonView;

    public void Start() {
        if(this.photonView.isMine){
            z = ponteiro.eulerAngles.z;
        }
        else{
            Destroy(ponteiroRpm);
        }
    }

    public void FixedUpdate() {
        if(this.photonView.isMine){
            if(rearDriverW.rpm < 1){
                z =  80 + (rearDriverW.rpm / 10);
            }
            else if(rearDriverW.rpm > -1){
                z =  80 - (rearDriverW.rpm / 10);
            }
    	    Vector3 steer = new Vector3(0,0,z);
            ponteiro.eulerAngles = steer;
        }
        else{
            Destroy(ponteiroRpm);
        }   
    }   
}
