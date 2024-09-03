using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class CoreStartPoint : MonoSingleton<CoreStartPoint>
{
    public YandexGame YandexGame { get; private set; }
    public LevelLoader LevelLoader { get; private set; }
    
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // Construct classes
        // GetComponentInChildren Systems
        
        // IF system == null create system in children
        
        // IF system != null initialize
        
        
        // Initializing LoadingManager
        LevelLoader = GetComponentInChildren<LevelLoader>();
        // Initializing Yandex
        YandexGame = GetComponentInChildren<YandexGame>();
        
        // Initializing Data
        // Initializing InputSystem
        // Initializing MainMenuManager
        // Initializing GameUIManager
        // Initializing ToolTipsManager
        // Initializing MainSoundManager
        // Initializing MainMusicManager
        // Initializing MainPlayerSkillsManager
        // Initializing MainSettingsManager
        
    }

    private async void Start()
    {
        await LevelLoader.LoadNewSceneAsync();
    }
}
