using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearSelect : Photon.MonoBehaviour
{
    public GameObject car;
    public string gear;
    public GameObject text;
    public Text gearText;
    public PhotonView photonView;

    public void Start() {
        gearText = text.GetComponent<Text>();
        if(!this.photonView.isMine){
            Destroy(text);
        }
    }

    public void FixedUpdate() {
        if(this.photonView.isMine){
            gear = car.GetComponent<CarController>().gear;
            gearText.text = gear;
        }
        else{
            Destroy(photonView);
        }
    }
}
