using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1stPerson : MonoBehaviour
{
	public bool lockCursor;
    public float m_xInput;
    public float m_yInput;
    public float mouseSensivity = 1;
    public Transform Camera;
    public Transform carro;

    //So é usada no inicio do jogo e serve para esconder o rato
    private void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    //Serve para saber para onde o rato se move (direita ou esquerda), so roda a camera.
    private void GetInput(){
		m_xInput += Input.GetAxis("Mouse X") * mouseSensivity;
        m_yInput -= Input.GetAxis("Mouse Y") * mouseSensivity;
    }

    //Atribui as variaveis a respetiva input do rato e aplica a rotação a camera usando um vetor.
    private void Move(){
        float x = -carro.eulerAngles.x + m_yInput;
        float y = 180 + carro.eulerAngles.y + m_xInput;
        float z = carro.eulerAngles.z;
        Vector3 move = new Vector3(x,y,z);
    	Camera.eulerAngles = move;
    }

    //Usa a função a cada frame e chama as funções de movimentação de camera.
    private void FixedUpdate(){
    	GetInput();
    	Move();
    }
}
