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
    //Guarda nas variaveis o input do teclado.
    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    /*Pega no input do teclado aplica as rodas das frente o metodo SteerAngle,
    movimentação da roda, é invisivel.*/
    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        if(Convert.ToInt32(speedtext) > 10){
            frontDriverW.steerAngle = m_steeringAngle - 17;
            frontPassengerW.steerAngle = m_steeringAngle - 17;
        }
        else{
            frontDriverW.steerAngle = m_steeringAngle;
            frontPassengerW.steerAngle = m_steeringAngle;
        }
    }

    /*Pega na função de cima, Steer(), é aplica fisicamente ao carro, é visivel */
    private void WheelTurn(){
    	float x = wheel.eulerAngles.x;
    	float y = wheel.eulerAngles.y;
    	float z;
    	z = m_steeringAngle * 2;
    	Vector3 steer = new Vector3(x,y,z);
    	wheel.eulerAngles = steer;
    }

    /*Vê se a tecla presionada foi o espaço mete os travões de tras 2x mais forte.*/
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

    private void Brakes(){ //Função Travões
        if(gear.text != "N" && gear.text != "R"){ //Verifica se está em neutra ou em marcha-atrás
            if(m_verticalInput < 0){ //Verifica se o Input Do teclado é negativo(Tá a carregar no S ou Seta pra baixo)
                frontDriverW.brakeTorque = brakeForce / 3;
                frontPassengerW.brakeTorque = brakeForce / 3;
            }
            else if(HandBrakeCheck == false){ //Verifica se o travão de mão tá ativo e põe os valores dos travões a 0
                rearDriverW.brakeTorque = 0;
                rearPassengerW.brakeTorque = 0;
                frontDriverW.brakeTorque = 0;
                frontPassengerW.brakeTorque = 0;
            }
        }
        else if(gear.text == "R"){ //Verifica se tá em marcha-atrás
        	if(m_verticalInput > 0){ //Se tiver e carregar no W (m_verticalInput = 1) trava o carro
                frontDriverW.brakeTorque = brakeForce;
                frontPassengerW.brakeTorque = brakeForce;
                rearDriverW.brakeTorque = brakeForce / 10;
                rearPassengerW.brakeTorque = brakeForce / 10;
            }
            else if(HandBrakeCheck == false){
                rearDriverW.brakeTorque = 0;
                rearPassengerW.brakeTorque = 0;
                frontDriverW.brakeTorque = 0;
                frontPassengerW.brakeTorque = 0;
            }
        }
    }

    private void burnout(){
        if(Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.S) && speedtext.text == "0"){
            rearDriverW.motorTorque = 1 * motorForce;
           	rearPassengerW.motorTorque = 1 * motorForce;
            frontDriverW.brakeTorque = brakeForce * 9000;
            frontPassengerW.brakeTorque = brakeForce * 9000;
            rearDriverW.brakeTorque = 0;
            rearPassengerW.brakeTorque = 0;
        }
    }

    private void Accelerate()
    {
        if(gearbox == "AWD"){
            if(gear.text == "R" || gear.text == "6"){//Verifica se esta em marcha-atras as rodas andam para tras.
           	    rearDriverW.motorTorque = m_verticalInput * motorForce;
           	    rearPassengerW.motorTorque = m_verticalInput * motorForce;
                frontDriverW.motorTorque = m_verticalInput * motorForce;
           	    frontPassengerW.motorTorque = m_verticalInput * motorForce;
            }
            else if(gear.text == "D" || gear.text == "1"){//Verifica se esta em 1 (Automatico) se tiver as rodas andam para frente numa velocidade de 5 * 2.5
        	    rearDriverW.motorTorque = m_verticalInput * (motorForce * 2.5f);
           	    rearPassengerW.motorTorque = m_verticalInput * (motorForce * 2.5f);
                frontDriverW.motorTorque = m_verticalInput * (motorForce * 2.5f);
           	    frontDriverW.motorTorque = m_verticalInput * (motorForce * 2.5f);
            }
            else if(gear.text == "2"){//Verifica se esta em 2 se tiver as rodas andam para frente numa velocidade de 5 * 2
           	    rearDriverW.motorTorque = m_verticalInput * (motorForce * 2);
           	    rearPassengerW.motorTorque = m_verticalInput * (motorForce * 2);
                frontDriverW.motorTorque = m_verticalInput * (motorForce * 2);
           	    frontDriverW.motorTorque = m_verticalInput * (motorForce * 2);
            }
            else if(gear.text == "3"){//Verifica se esta em 3 se tiver as rodas andam para frente numa velocidade de 5 * 1.5
           	    rearDriverW.motorTorque = m_verticalInput * (motorForce * 1.5f);
           	    rearPassengerW.motorTorque = m_verticalInput * (motorForce * 1.5f);
                frontDriverW.motorTorque = m_verticalInput * (motorForce * 1.5f);
           	    frontDriverW.motorTorque = m_verticalInput * (motorForce * 1.5f);
            }
            else if(gear.text == "4"){//Verifica se esta em 4 se tiver as rodas andam para frente numa velocidade de 5 * 1
          	    rearDriverW.motorTorque = m_verticalInput * (motorForce * 1);
           	    rearPassengerW.motorTorque = m_verticalInput * (motorForce * 1);
                frontDriverW.motorTorque = m_verticalInput * (motorForce * 1);
           	    frontDriverW.motorTorque = m_verticalInput * (motorForce * 1);
            }
            else if(gear.text == "5"){//Verifica se esta em 5 se tiver as rodas andam para frente numa velocidade de 5 * 5
           	    rearDriverW.motorTorque = m_verticalInput * (motorForce * .5f);
           	    rearPassengerW.motorTorque = m_verticalInput * (motorForce * .5f);
                frontDriverW.motorTorque = m_verticalInput * (motorForce * .5f);
           	    frontDriverW.motorTorque = m_verticalInput * (motorForce * .5f);
            }
        }
        else if(gearbox=="RWD"){
            if(gear.text == "R" || gear.text == "6"){//Verifica se esta em marcha-atras as rodas andam para tras.
           	    rearDriverW.motorTorque = m_verticalInput * motorForce;
           	    rearPassengerW.motorTorque = m_verticalInput * motorForce;
                frontDriverW.motorTorque = m_verticalInput * motorForce;
           	    frontPassengerW.motorTorque = m_verticalInput * motorForce;
            }
            else if(gear.text == "D" || gear.text == "1"){//Verifica se esta em 1 (Automatico) se tiver as rodas andam para frente numa velocidade de 5 * 2.5
        	    rearDriverW.motorTorque = m_verticalInput * (motorForce * 2.5f);
           	    rearPassengerW.motorTorque = m_verticalInput * (motorForce * 2.5f);
                frontDriverW.motorTorque = m_verticalInput * (motorForce * 2.5f);
           	    frontDriverW.motorTorque = m_verticalInput * (motorForce * 2.5f);
            }
            else if(gear.text == "2"){//Verifica se esta em 2 se tiver as rodas andam para frente numa velocidade de 5 * 2
           	    rearDriverW.motorTorque = m_verticalInput * (motorForce * 2);
           	    rearPassengerW.motorTorque = m_verticalInput * (motorForce * 2);
                frontDriverW.motorTorque = m_verticalInput * (motorForce * 2);
           	    frontDriverW.motorTorque = m_verticalInput * (motorForce * 2);
            }
            else if(gear.text == "3"){//Verifica se esta em 3 se tiver as rodas andam para frente numa velocidade de 5 * 1.5
           	    rearDriverW.motorTorque = m_verticalInput * (motorForce * 1.5f);
           	    rearPassengerW.motorTorque = m_verticalInput * (motorForce * 1.5f);
                frontDriverW.motorTorque = m_verticalInput * (motorForce * 1.5f);
           	    frontDriverW.motorTorque = m_verticalInput * (motorForce * 1.5f);
            }
            else if(gear.text == "4"){//Verifica se esta em 4 se tiver as rodas andam para frente numa velocidade de 5 * 1
          	    rearDriverW.motorTorque = m_verticalInput * (motorForce * 1);
           	    rearPassengerW.motorTorque = m_verticalInput * (motorForce * 1);
                frontDriverW.motorTorque = m_verticalInput * (motorForce * 1);
           	    frontDriverW.motorTorque = m_verticalInput * (motorForce * 1);
            }
            else if(gear.text == "5"){//Verifica se esta em 5 se tiver as rodas andam para frente numa velocidade de 5 * 5
           	    rearDriverW.motorTorque = m_verticalInput * (motorForce * .5f);
           	    rearPassengerW.motorTorque = m_verticalInput * (motorForce * .5f);
                frontDriverW.motorTorque = m_verticalInput * (motorForce * .5f);
           	    frontDriverW.motorTorque = m_verticalInput * (motorForce * .5f);
            }
        }
	}

    private void ChangeGear(){//Só para carros automaticos
    	if(gear.text == "D" && speedtext.text == "0"){//Se tiver em D e a velocidade for 0 passa para N, neutra.
    		gear.text = "N";
    	}
    	else if(gear.text == "R" && speedtext.text == "0"){//Se tiver em R e a velocidade for 0 passa para N, neutra.
    		gear.text = "N";
    	}
    }

    /*Chama 4 vezes a mesma função mas de cada so manda 1 roda diferente */
    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    /*pega no collider que recebe da função de cima e aplica rotação e posição as rodas */
    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    //Chama todas estas funções
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        burnout();
        Accelerate();  
        HandBrake();
        WheelTurn();
        Brakes();
        UpdateWheelPoses();
        ChangeGear();
    }

    //Atribui estas variaveis um GetComponent de texto 
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
    public bool isAccel = false;
    public string gearbox = "";

    public GameObject gearText;
    private Text gear;

    public GameObject geartype;
    private Text gearmode;

    public GameObject speed;
    private Text speedtext;
}
