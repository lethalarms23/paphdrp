using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    //A camera fixa no personagem.
    public void LookAtTarget()
    {
        Vector3 _lookDirection = objectToFollow.position - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
    }

    //Consoante o movimento do target a camera, como esta focada nele, vai andar sempre atras do target.
    public void MoveToTarget()
    {
    	Vector3 _targetPos = objectToFollow.position + objectToFollow.forward * offset.z + objectToFollow.right * offset.x + objectToFollow.up * offset.y;
    	transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
    }

    //Usa a função a cada frame e chama as funções LookAtTarget e MoveToTarget.
    private void FixedUpdate()
    {
    	LookAtTarget();
    	MoveToTarget();	
    }

    public Transform objectToFollow;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;
}
