using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public void Start(){
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        SetQuality(2);
    }

    public void Play(){
        PhotonNetwork.offlineMode = true;
        PhotonNetwork.CreateRoom("single-player");
        SceneManager.LoadScene("Game");
    }

    public void Multiplayer(){
        SceneManager.LoadScene("OnlineMenu");
    }

    public void Options(){
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void OptionsBack(){
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public void Exit(){
        Application.Quit();
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
