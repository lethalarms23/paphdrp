using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrialStop : MonoBehaviour
{
    public GameObject timer;
    public GameObject TimeStop;
    public GameObject TimeStart;

    private void OnTriggerEnter(Collider other) {
        timer.GetComponent<TimeTrial>().SetTimer(false);
        TimeStop.SetActive(false);
        TimeStart.SetActive(true);
    }
}
