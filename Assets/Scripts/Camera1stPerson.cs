using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1stPerson : MonoBehaviour
{
	public bool lockCursor;
    public float m_xInput;
    public float m_yInput;
    public float mouseSensivity = 0;
    public Transform Camera;

    private void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void GetInput(){
		m_xInput += Input.GetAxis("Mouse X") * mouseSensivity;
        m_yInput -= Input.GetAxis("Mouse Y") * mouseSensivity;
    }

    private void Move(){
    	float x = m_xInput;
    	float y = m_yInput;
    	float z = 0;
    	Vector3 move = new Vector3(y,x,z);
    	Camera.eulerAngles = move;
    }

    private void FixedUpdate(){
    	GetInput();
    	Move();
    }

}
