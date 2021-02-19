using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriftPoints : MonoBehaviour
{
    public WheelCollider rearDriverW;
    public float driftPoints;
    public float combo = 300; 
    public GameObject text;
    public Text drift;

    public void Start() {
        drift = text.GetComponent<Text>();
    }

    public void FixedUpdate() {
        WheelHit wheelHit;
        float blind = 0.28f;
        rearDriverW.GetGroundHit(out wheelHit);
        if(wheelHit.sidewaysSlip > blind || wheelHit.sidewaysSlip < -blind){
			driftPoints += blind * combo * Time.deltaTime;
            
		}
        drift.text = driftPoints.ToString("#");
    }
    
}
