using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    public void Start(){
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        SetQuality(2);
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
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

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
}
