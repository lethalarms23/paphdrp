using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource audio;
    public void OnPointerEnter(PointerEventData eventData){
        audio.Play();
    }
    public void OnPointerExit(PointerEventData eventData){

    }
}
