using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeTrial : MonoBehaviour
{
    public GameObject[] checkpoints;
    public GameObject timerStart;
    public GameObject timerStop;
    Renderer rend;
    public bool isTimer = false;
    public float savetime = 0f;
    public float timer;
    public int milisec;
    public string saveTimeString;

    private void Start()
    { 
        rend = GetComponent<Renderer>();
    }

    public void FixedUpdate() {
        if(isTimer == true){
            Timer();
        }
        else{
            SaveTime();
        }
    }

    public void SetTimer(bool TF){
        this.isTimer = TF;
    }

    public void SaveTime(){
        if(timer > 1){
            if(timer < savetime || savetime == 0f){
                savetime = timer;
                milisec = (int)(timer * 1000);
                milisec = milisec % 1000;
                saveTimeString = (TimeSpan.FromSeconds(timer).Hours) + "h:"+(TimeSpan.FromSeconds(timer).Minutes)+"m:"+(TimeSpan.FromSeconds(timer).Seconds)+"s:"+milisec+"ms";
                timer = 0f;
            }
            else{
                timer = 0f;
            }
        }
        else{
            timer = 0f;
        }
    }

    public void Timer(){
        timer += Time.deltaTime;
    }
}
