using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrial : MonoBehaviour
{
    public GameObject[] checkpoints;
    public GameObject timerStart;
    public GameObject timerStop;
    Renderer rend;
    public bool isTimer = false;
    public float m;
    public float s;
    public float h;
    public float savetime = 0f;
    public float savetimetemp = 0f;
    public string sametimestring = "";
    public string timestring;

    private void Start()
    { 
        rend = GetComponent<Renderer>();
    }

    public void FixedUpdate() {
        if(isTimer == true){
            Timer();
        }
    }

    public void SetTimer(bool TF){
        if(m != 0 || s != 0 || h != 0){
            m = 0;
            s = 0;
            h = 0;
        }
        isTimer = TF;
    }

    public void SaveTime(){
        if(savetime != 0){
            timestring = m.ToString() + s.ToString();
            if(savetimetemp < savetime){
                savetime = savetimetemp;
                timestring = m.ToString()+"m "+s.ToString("00.00")+"s";
            }
            else{

            }
        }
        else{
            timestring = m.ToString()+"m "+s.ToString("00.00")+"s";
            savetime = float.Parse(timestring);
        }
        Debug.Log(timestring);
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
}
