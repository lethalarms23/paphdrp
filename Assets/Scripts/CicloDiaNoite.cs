using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDiaNoite : MonoBehaviour
{
    public Transform luz;
    public float x;

    public void Start() {
        x = luz.eulerAngles.x;
    }

    public void GetPos(){
        x = x + 0.1f * Time.deltaTime;
    }

    public void Rotate(){
        Vector3 rotate = new Vector3(x,300,0);
        luz.eulerAngles = rotate;
    }

    public void FixedUpdate() {
        GetPos();
        Rotate();
    }
}
