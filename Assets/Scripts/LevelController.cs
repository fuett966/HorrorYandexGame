using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoSingleton<LevelController>
{
    [SerializeField] private PlayerCharacterController _playerCharacterController;
    [SerializeField] private MainPlayerController _mainPlayerController;
    [SerializeField] private PlayerCameraController _playerCameraController;
        

    public void SetEnabledCharacterMovement(bool _value)
    {
        _mainPlayerController.enabled = _value;
        _playerCharacterController.SetAFK(true);
    }
}
