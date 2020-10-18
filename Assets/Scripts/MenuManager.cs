using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuPT;
    public GameObject Jogo;

    public void EnterGame(){
        MenuPT.SetActive(false);
        Jogo.SetActive(true);
    }

    public void FixedUpdate() {
        if(Input.GetKeyUp(KeyCode.Escape)){
            MenuPT.SetActive(true);
            Jogo.SetActive(false);
        }
    }
}
