using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearSelect : MonoBehaviour
{
    public GameObject gearText;
    private Text gear;
    public GameObject gearType;
    private Text gearmode;

    public void Start(){
    	gear = gearText.GetComponent<Text>();
    	gearmode = gearType.GetComponent<Text>();
    }

    public void FixedUpdate(){
    	if(Input.GetKeyUp(KeyCode.N)){
    		if(gearmode.text == "Man"){
    			gearmode.text = "Auto";
    		}
    		else{
    			gearmode.text = "Man";
    		}
    	}

    	if(gearmode.text=="Man"){
    		if(Input.GetKeyUp(KeyCode.R)){
    			gear.text = "R";
    		}
    		else if(Input.GetKeyUp(KeyCode.Alpha0)){
    			gear.text = "N";
    		}
    		else if(Input.GetKeyUp(KeyCode.Alpha1)){
    			gear.text = "1";
    		}
    		else if(Input.GetKeyUp(KeyCode.Alpha2)){
    			gear.text = "2";
    		}
    		else if(Input.GetKeyUp(KeyCode.Alpha3)){
    			gear.text = "3";
    		}
    		else if(Input.GetKeyUp(KeyCode.Alpha4)){
    			gear.text = "4";
    		}
    		else if(Input.GetKeyUp(KeyCode.Alpha5)){
    			gear.text = "5";
    		}
    		else if(Input.GetKeyUp(KeyCode.Alpha6)){
    			gear.text = "6";
    		}
    	}
    }
}
