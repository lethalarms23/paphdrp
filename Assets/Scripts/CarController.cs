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
    	z = m_steeringAngle * 2;
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
        if(gear == "D"){
            if(m_verticalInput < 0){
                frontDriverW.brakeTorque = brakeForce / 3;
                frontPassengerW.brakeTorque = brakeForce / 3;
                
            }
            else{
                frontDriverW.brakeTorque = 0;
                frontPassengerW.brakeTorque = 0;
            }
        }
        else if(gear == "R"){
            if(m_verticalInput > 0){
                frontDriverW.brakeTorque = brakeForce / 3;
                frontPassengerW.brakeTorque = brakeForce / 3;
            }
            else{
                frontDriverW.brakeTorque = 0;
                frontPassengerW.brakeTorque = 0;
            }
        }
    }

    private void burnout(){
        if(Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.S) && speed == "0"){
            rearDriverW.motorTorque = 1 * motorForce;
           	rearPassengerW.motorTorque = 1 * motorForce;
            frontDriverW.brakeTorque = brakeForce * 9000;
            frontPassengerW.brakeTorque = brakeForce * 9000;
            rearDriverW.brakeTorque = 0;
            rearPassengerW.brakeTorque = 0;
        }
    }

    private void Velocity(){
        carVelocity = (rigidCar.velocity.magnitude * 2.237f * Time.deltaTime) * 100;
		if(carVelocity < 1){
			speed = "0";
		}
		else{
			speed = carVelocity.ToString("#");
		}
    }

    private void Accelerate()
    {
        rearDriverW.motorTorque = m_verticalInput * motorForce;
        rearPassengerW.motorTorque = m_verticalInput * motorForce;
        frontDriverW.motorTorque = m_verticalInput * motorForce;
        frontPassengerW.motorTorque = m_verticalInput * motorForce;
	}

    private void ChangeGear(){
        if(gear == "N" && m_verticalInput > 0 ){
            gear = "D";
        }
        else if(gear == "N" && m_verticalInput < 0){
            gear = "R";
        }
    	else if(gear == "D" && speed == "0"){
    		gear = "N";
    	}
    	else if(gear == "R" && speed == "0"){
    		gear = "N";
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
        burnout();
        Accelerate();  
        HandBrake();
        WheelTurn();
        Brakes();
        Velocity();
        UpdateWheelPoses();
        ChangeGear();
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
    public string gearbox = "";
    public string gear = "N";
    public string speed;
    public float carVelocity;
    public Rigidbody rigidCar;
}
