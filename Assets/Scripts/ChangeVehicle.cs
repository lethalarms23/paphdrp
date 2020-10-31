using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVehicle : MonoBehaviour
{
    public GameObject motoCamera;
    public GameObject carCamera;

    public void FixedUpdate() {
        if(Input.GetKeyDown(KeyCode.B)){
            if(motoCamera.activeSelf){
                carCamera.SetActive(true);
                motoCamera.SetActive(false);
            }
            else{
                carCamera.SetActive(false);
                motoCamera.SetActive(true);
            }
        }
    }
}
