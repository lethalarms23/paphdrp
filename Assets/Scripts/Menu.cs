using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject titan;
    public GameObject Rx7;
    public GameObject driftPlayground;
    public GameObject SunCity;
    public GameObject Rx7Prefab;
    public GameObject TitanPrefab;

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
        PhotonNetwork.Instantiate(TitanPrefab.name, new Vector3(titan.transform.position.x, titan.transform.position.y,titan.transform.position.z),Quaternion.identity,0);
        CarroMenu.SetActive(false);
        start.SetActive(true);
    }

    public void Rx7Select(){
        //Rx7.SetActive(true);
        PhotonNetwork.Instantiate(Rx7Prefab.name, new Vector3(Rx7.transform.position.x, Rx7.transform.position.y,Rx7.transform.position.z),Quaternion.identity,0);
        CarroMenu.SetActive(false);
        start.SetActive(true); 
    }  
    
    public void driftPlaygroundSelect(){
        driftPlayground.SetActive(true);
        PistaMenu.SetActive(false);
        CarroMenu.SetActive(true);
    }

    public void SunCitySelect(){
        SunCity.SetActive(true);
        PistaMenu.SetActive(false);
        CarroMenu.SetActive(true);
    }

    public void BugHunter(){
        Debug.Log("Pressed");
    }

    public void Play() {
        SceneManager.LoadScene("Game");
    }

    public void Multiplayer(){
        SceneManager.LoadScene("OnlineMenu");
    }

    public void Options(){

    }

    public void Exit(){
        Application.Quit();
    }
}
