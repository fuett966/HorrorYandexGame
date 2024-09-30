using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoSingleton<LevelController>
{
    [SerializeField] private AudioClip _ambient;
    [SerializeField] private int _ambientNumber;
    [SerializeField] private PlayerCharacterController _playerCharacterController;
    [SerializeField] private MainPlayerController _mainPlayerController;
    [SerializeField] private PlayerCameraController _playerCameraController;
    [SerializeField] private bool _activateBPMAnalyzer = false;

    private void Start()
    {
        //MainAudioManager.instance.PlayMainSourceAudio(AddressableManager.instance.AmbientData[_ambientNumber].Asset as AudioClip);
        MainAudioManager.instance.PlayMainSourceAudio(_ambient);
        if (_activateBPMAnalyzer)
        {
            BeatManager.instance.AnalyzeClip();
        }
    }

    public void SetEnabledCharacterMovement(bool _value)
    {
        _mainPlayerController.enabled = _value;
        _playerCharacterController.SetAFK(true);
    }
}
