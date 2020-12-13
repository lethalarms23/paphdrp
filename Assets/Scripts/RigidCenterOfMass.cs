using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidCenterOfMass : MonoBehaviour
{
    public Vector3 com;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com;
    }
}
