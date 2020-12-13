using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3rdPerson : MonoBehaviour
{
    public bool lockCursor;
    public float mouseSensivity;
    public Transform target;
    public float distanceFromTarget = 2;
    
    public Vector2 pitchMinMax = new Vector2(-40, 85);

    public float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    float zoomSens=2;
    float zoom;
    float yaw;
    float pitch;

    //Só é usada no incio do jogo e serve para esconder o rato
    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void zoomTarget(){
        zoom = -(Input.GetAxis("Mouse ScrollWheel") * zoomSens);
        distanceFromTarget += zoom;
    }

    //Atribui as variaveis o input do rato e consoante o valor gira em volta do target(personagem)
    void LateUpdate()
    {
        zoomTarget();
        yaw += Input.GetAxis("Mouse X") * mouseSensivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
