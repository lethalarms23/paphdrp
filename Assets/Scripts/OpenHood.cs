using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHood : MonoBehaviour
{
    public Animator animator;
    public int isOpen = 0;
    
    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.M) && isOpen == 0){
            isOpen = 1;
            animator.SetInteger("isOpen",1);
        }
        else if(Input.GetKeyDown(KeyCode.M)){
            isOpen = 0;
            animator.SetInteger("isOpen",0);
        }
    }
}
