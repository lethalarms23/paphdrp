using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera3;

    private void FixedUpdate(){
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
