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
		//Troca entre manual e automático
    	if(Input.GetKeyUp(KeyCode.N)){
    		if(gearmode.text == "Man"){
    			gearmode.text = "Auto";
    		}
    		else if(gearmode.text == "Auto"){
    			gearmode.text = "Seq";
    		}
			else{
				gearmode.text = "Man";
			}
    	}

		//Mudanças Automáticas
		if(gearmode.text == "Auto"){
			if(Input.GetAxis("Vertical") > 0 && gear.text == "N"){
				gear.text = "D";
			}
			else if(Input.GetAxis("Vertical") < 0 && gear.text == "N"){
				gear.text = "R";
			}
		}
    }
}
