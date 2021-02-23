using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : Photon.MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera3;
    public PhotonView photonView;

    private void FixedUpdate(){
        if(this.photonView.isMine){
            if(Input.GetKeyUp(KeyCode.V)){
            if(Camera1.activeSelf){
                Camera1.SetActive(false);
                Camera3.SetActive(true);
            }
            else if(Camera3.activeSelf){
                Camera3.SetActive(false);
                Camera1.SetActive(true);
            }
            }
        }   
    }

    private void Start(){
        if(!photonView.isMine){
            Destroy(Camera1);
            Destroy(Camera3);
        }
    }

}
