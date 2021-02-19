using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrial : MonoBehaviour
{
    Renderer rend;
    public bool isTimer = false;
    public float m;
    public float s;
    public float h;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void FixedUpdate() {
        if(isTimer == true){
            Timer();
        }
    }

    public void Timer(){
        if(s < 59){
            s += 1 * Time.deltaTime;
        }
        else if(s > 59 && m < 59){
            s = 0;
            m += 1;
        }
        else{
            s = 0; 
            m = 0;
            h += 1;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(isTimer == false && s == 0){
            isTimer = true;
        }
        else if(isTimer == true && s > 5){
            isTimer = false;
        }
    }
}
