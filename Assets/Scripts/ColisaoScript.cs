using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoScript : MonoBehaviour
{
    public GameObject driftScript;

    public void OnTriggerEnter(Collider other){
        driftScript.GetComponent<DriftPoints>().combo = 0;
        driftScript.GetComponent<DriftPoints>().driftPoints = 0;
    }
}
