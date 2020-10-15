using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;
    }

    private void WheelTurn(){
    	float x = wheel.eulerAngles.x;
    	float y = wheel.eulerAngles.y;
    	float z;
    	z = -(m_steeringAngle * 2);
    	Vector3 steer = new Vector3(x,y,z);
    	wheel.eulerAngles = steer;
    }

    private void HandBrake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            HandBrakeCheck = true;
        	rearDriverW.brakeTorque = brakeForce * 10;
            rearPassengerW.brakeTorque = brakeForce * 10;
            UpdateWheelPoses();
        }
        else{
            HandBrakeCheck = false;
            rearDriverW.brakeTorque = 0;
            rearPassengerW.brakeTorque = 0;
        }
    }

    private void Brakes(){
        if(gear.text != "N" && gear.text != "R"){
            if(m_verticalInput < 0){
                rearDriverW.brakeTorque = brakeForce / 4;
                rearPassengerW.brakeTorque = brakeForce / 4;
                frontDriverW.brakeTorque = brakeForce / 3;
                frontPassengerW.brakeTorque = brakeForce / 3;
            }
            else if(HandBrakeCheck == false){
                rearDriverW.brakeTorque = 0;
                rearPassengerW.brakeTorque = 0;
                frontDriverW.brakeTorque = 0;
                frontPassengerW.brakeTorque = 0;
            }
        }
        else if(gear.text == "R"){
        	if(m_verticalInput > 0){
                rearDriverW.brakeTorque = brakeForce / 4;
                rearPassengerW.brakeTorque = brakeForce / 4;
                frontDriverW.brakeTorque = brakeForce / 3;
                frontPassengerW.brakeTorque = brakeForce / 3;
            }
            else if(HandBrakeCheck == false){
                rearDriverW.brakeTorque = 0;
                rearPassengerW.brakeTorque = 0;
                frontDriverW.brakeTorque = 0;
                frontPassengerW.brakeTorque = 0;
            }
        }
    }

    private void Accelerate()
    {
 		if(gear.text == "R"){
           	rearDriverW.motorTorque = m_verticalInput * motorForce;
           	rearPassengerW.motorTorque = m_verticalInput * motorForce;
        }
        else if(gear.text == "1"){
           	rearDriverW.motorTorque = m_verticalInput * (motorForce * 2.5f);
           	rearPassengerW.motorTorque = m_verticalInput * (motorForce * 2.5f);
        }
        else if(gear.text == "2"){
           	rearDriverW.motorTorque = m_verticalInput * (motorForce * 2);
           	rearPassengerW.motorTorque = m_verticalInput * (motorForce * 2);
        }
        else if(gear.text == "3"){
           	rearDriverW.motorTorque = m_verticalInput * (motorForce * 1.5f);
           	rearPassengerW.motorTorque = m_verticalInput * (motorForce * 1.5f);
        }
        else if(gear.text == "4"){
          	rearDriverW.motorTorque = m_verticalInput * (motorForce * 1);
           	rearPassengerW.motorTorque = m_verticalInput * (motorForce * 1);
        }
        else if(gear.text == "5"){
           	rearDriverW.motorTorque = m_verticalInput * (motorForce * .5f);
           	rearPassengerW.motorTorque = m_verticalInput * (motorForce * .5f);
        }
        else if(gear.text == "6"){
           	rearDriverW.motorTorque = m_verticalInput * (motorForce);
           	rearPassengerW.motorTorque = m_verticalInput * (motorForce);
        }
        else if(gear.text == "D"){
        	rearDriverW.motorTorque = m_verticalInput * (motorForce * 2.5f);
           	rearPassengerW.motorTorque = m_verticalInput * (motorForce * 2.5f);
        }

    //Automatic Gearbox
    if(gearmode.text == "Auto"){
       	if(gear.text == "N"){
       		if(m_verticalInput > 0){
       			gear.text = "D";
       			rearDriverW.motorTorque = m_verticalInput * (motorForce * 2.5f);
            	rearPassengerW.motorTorque = m_verticalInput * (motorForce * 2.5f);
       		}
       		else if(m_verticalInput < 0){
       			gear.text = "R";
       			rearDriverW.motorTorque = m_verticalInput * motorForce;
            	rearPassengerW.motorTorque = m_verticalInput * motorForce;
       		}
       	}
    }
	}

    private void ChangeGear(){
    	if(gear.text == "D" && speedtext.text == "0"){
    		gear.text = "N";
    	}
    	else if(gear.text == "R" && speedtext.text == "0"){
    		gear.text = "N";
    	}
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();  
        HandBrake();
        WheelTurn();
        Brakes();
        UpdateWheelPoses();
        ChangeGear();
    }

    private void Start(){
        gear = gearText.GetComponent<Text>();
        gearmode = geartype.GetComponent<Text>();
        speedtext = speed.GetComponent<Text>();
    }


    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public Transform wheel;
    public float maxSteerAngle = 30;
    public float motorForce = 5;
    public float brakeForce = 700;
    public bool HandBrakeCheck = false;

    public GameObject gearText;
    private Text gear;

    public GameObject geartype;
    private Text gearmode;

    public GameObject speed;
    private Text speedtext;
}
