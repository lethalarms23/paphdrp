using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject titan;
    public GameObject Rx7;
    public GameObject Rx7Prefab;
    public GameObject TitanPrefab;
    public GameObject EvoXPrefab;
    public GameObject EvoX;
    public GameObject driftPlaygroundPrefab;
    public GameObject sunCityPrefab;

    public GameObject PistaMenu;
    public GameObject CarroMenu;
    public GameObject start;
    public GameObject mainMenu;
    public GameObject secondMenu;
    public GameObject optionsMenu;

    public void PlayV2(){
        secondMenu.SetActive(false);
    }

    public void Start(){
        if(PhotonNetwork.isMasterClient == false){
            PistaMenu.SetActive(false);
            CarroMenu.SetActive(true);
        }
    }

    public void FixedUpdate() {
        // if(Input.GetKey(KeyCode.Escape)){
        //     secondMenu.SetActive(true);
        //     Cursor.lockState = CursorLockMode.Locked;
        //     Cursor.visible = false;
        // }
    }

    public void TitanSelect(){
        PhotonNetwork.Instantiate(TitanPrefab.name, new Vector3(titan.transform.position.x, titan.transform.position.y,titan.transform.position.z),Quaternion.identity,0);
        CarroMenu.SetActive(false);
        start.SetActive(true);
    }

    public void Rx7Select(){
        PhotonNetwork.Instantiate(Rx7Prefab.name, new Vector3(Rx7.transform.position.x, Rx7.transform.position.y,Rx7.transform.position.z),Quaternion.identity,0);
        CarroMenu.SetActive(false);
        start.SetActive(true); 
    }  

    public void EvoXSelect(){
        PhotonNetwork.Instantiate(EvoXPrefab.name, new Vector3(EvoX.transform.position.x, EvoX.transform.position.y,EvoX.transform.position.z),Quaternion.identity,0);
        CarroMenu.SetActive(false);
        start.SetActive(true); 
    }
    
    public void driftPlaygroundSelect(){
        PhotonNetwork.Instantiate(driftPlaygroundPrefab.name, new Vector3(-921.9f, -97.9f,71.57524f),Quaternion.identity,0);
        PistaMenu.SetActive(false);
        CarroMenu.SetActive(true);
    }

    public void SunCitySelect(){
        PhotonNetwork.Instantiate(sunCityPrefab.name, new Vector3(-972.9f, -38f,48.31f),Quaternion.identity,0);
        PistaMenu.SetActive(false);
        CarroMenu.SetActive(true);
    }

    public void BugHunter(){
        Debug.Log("Pressed");
    }

    public void exitLobby(){
        SceneManager.LoadScene("MainMenu");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    public void OptionsBack(){
        secondMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
