using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void Play(){
        PhotonNetwork.offlineMode = true;
        PhotonNetwork.CreateRoom("single-player");
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
