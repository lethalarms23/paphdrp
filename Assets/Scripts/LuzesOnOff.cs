using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzesOnOff : MonoBehaviour
{
    public GameObject Luzes;

    public void FixedUpdate(){
        if(Input.GetKeyDown(KeyCode.H)){
            if(Luzes.activeSelf){
                Luzes.SetActive(false);
            }
            else{
                Luzes.SetActive(true);
            }
        }
    }
}
