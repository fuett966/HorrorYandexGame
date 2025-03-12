using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject mobileButtons;
    [SerializeField] private GameObject touchSwipeInput;

    private void Awake()
    {
        mobileButtons.SetActive(false);
        touchSwipeInput.SetActive(false);
        // if(YandexGame.EnvironmentData.deviceType == "mobile")
        // {
        //     mobileButtons.SetActive(true);
        //     touchSwipeInput.SetActive(true);
        // }
        // else if(YandexGame.EnvironmentData.deviceType == "desktop")
        // {
        //     
        // }
    }
    private void Start()
    {
        
    }
}
