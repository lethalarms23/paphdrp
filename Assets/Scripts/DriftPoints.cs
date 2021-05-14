using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriftPoints : Photon.MonoBehaviour
{
    public WheelCollider rearDriverW;
    public float driftPoints;
    public int combo = 0;
    public string BugSolve = null; 

    public GameObject text;
    public Text drift;

    public GameObject comboText;
    public Text combotxt;

    public PhotonView photonView;
    public GameObject particles;

    public GameObject timeT;
    public TimeTrial timetrial;

    public GameObject timerText;
    public Text timertxt;

    public void Start() {
        timeT = GameObject.Find("/Jogo/Pistas/driftplayground/TimeTrial");
        drift = text.GetComponent<Text>();
        combotxt = comboText.GetComponent<Text>();
        timertxt = timerText.GetComponent<Text>();
        timetrial = timeT.GetComponent<TimeTrial>();
        if(!this.photonView.isMine){
            Destroy(text);
            Destroy(drift);
            Destroy(comboText);
            Destroy(combotxt);
        }
    }

    public void driftPart(){
         if(this.photonView.isMine){
            WheelHit wheelHit;
            float blind = 0.15f;
            rearDriverW.GetGroundHit(out wheelHit);
            if(wheelHit.sidewaysSlip > blind || wheelHit.sidewaysSlip < -blind){
			    driftPoints += blind * combo * 1000 * Time.deltaTime;   
                particles.SetActive(true);
		    }
            else{ 
                particles.SetActive(false);
            }
            drift.text = driftPoints.ToString("#");
        }
        else{
            return;
        }
    }

    public void Combo(){
        if(this.photonView.isMine){
            WheelHit wheelHit;
            float blind = 0.15f;
            rearDriverW.GetGroundHit(out wheelHit);
            if(wheelHit.sidewaysSlip > blind && BugSolve != "false"){
                BugSolve = "false";
                combo = combo + 1;
		    }
            else if(wheelHit.sidewaysSlip < -blind && BugSolve != "true"){
                BugSolve = "true";
                combo = combo + 1;
            }
            combotxt.text = "Combo " + combo.ToString() + "x";
        }
        else{
            return;
        }
    }

    public void FixedUpdate() {
        driftPart();
        Combo();
        if(timetrial.isTimer == true){
            timertxt.text = timetrial.tempString;
        }
    }
    
}
