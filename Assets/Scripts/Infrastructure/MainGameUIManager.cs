using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class MainGameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject mobileButtons;
    [SerializeField] private GameObject touchSwipeInput;

    private void Awake()
    {
        if(YandexGame.EnvironmentData.deviceType == "mobile")
        {
            mobileButtons.SetActive(true);
            touchSwipeInput.SetActive(true);
        }
        else if(YandexGame.EnvironmentData.deviceType == "desktop")
        {
            mobileButtons.SetActive(false);
            touchSwipeInput.SetActive(false);
        }
    }
    private void Start()
    {
        
    }
}
