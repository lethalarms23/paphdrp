using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearSelect : MonoBehaviour
{
    public GameObject car;
    public string gear;
    public GameObject text;
    public Text gearText;

    public void Start() {
        gearText = text.GetComponent<Text>();
    }

    public void FixedUpdate() {
        gear = car.GetComponent<CarController>().gear;
        gearText.text = gear;
    }
}
