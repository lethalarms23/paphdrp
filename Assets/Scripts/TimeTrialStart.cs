using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrialStart : MonoBehaviour
{
    public GameObject TimeTrial;
    public GameObject TimeSelf;
    public GameObject TimeStop;

    private void OnTriggerEnter(Collider other) {
        TimeTrial.GetComponent<TimeTrial>().SetTimer(true);
        TimeSelf.SetActive(false);
        TimeStop.SetActive(true);
    }
}
