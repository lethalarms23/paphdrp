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
	private int text;

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

		//Mudanças Sequencias
		if(gearmode.text == "Seq"){
			if(Input.GetKeyUp(KeyCode.LeftShift)){
				if(gear.text == "N"){
					gear.text = "1";
				}
				else{
					if((int.Parse(gear.text) + 1) != 7){
						gear.text = (int.Parse(gear.text) + 1).ToString();
					}
				return;
				}
			}
			else if(Input.GetKeyUp(KeyCode.LeftControl)){
				if(gear.text == "N"){
					gear.text = "R";
				}
				else if(gear.text == "1"){
					gear.text = "N";
				}
				else{
					if(int.Parse(gear.text) > 1){
						gear.text = (int.Parse(gear.text) - 1).ToString();
					}
				return;
				}
			}
		}
    }
}
