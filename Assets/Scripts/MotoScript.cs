using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotoScript : MonoBehaviour
{

    public GameObject speedometer;
    private Text speed;

    void Start()
    {
        speed = speedometer.GetComponent<Text>();
    }

    void FixedUpdate()
    {
    }
}
