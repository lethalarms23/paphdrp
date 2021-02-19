using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject titan;
    public GameObject Rx7;
    public GameObject driftPlayground;
    public GameObject SunCity;

    public GameObject PistaMenu;
    public GameObject CarroMenu;
    public GameObject start;
    public GameObject mainMenu;
    public GameObject secondMenu;

    public void PlayV2(){
        secondMenu.SetActive(false);
    }

    public void FixedUpdate() {
        if(Input.GetKey(KeyCode.Escape)){
            secondMenu.SetActive(true);
        }
    }

    public void TitanSelect(){
        titan.SetActive(true);
        PistaMenu.SetActive(true);
        CarroMenu.SetActive(false);
    }

    public void Rx7Select(){
        Rx7.SetActive(true);
        PistaMenu.SetActive(true);
        CarroMenu.SetActive(false); 
    }
    
    public void driftPlaygroundSelect(){
        driftPlayground.SetActive(true);
        PistaMenu.SetActive(false);
        start.SetActive(true);
    }

    public void SunCitySelect(){
        SunCity.SetActive(true);
        start.SetActive(true);
        PistaMenu.SetActive(false);
    }

    public void BugHunter(){
        Debug.Log("Pressed");
    }

    public void Play() {
        CarroMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Options(){

    }

    public void Exit(){
        Application.Quit();
    }
}
