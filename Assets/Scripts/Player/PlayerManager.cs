using System;
using System.Collections;
using System.Collections.Generic;
using KinematicCharacterController.Examples;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    [Header("Variables")]
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private PlayerCharacterController _characterController;
    
    [Header("Audio")]
    [SerializeField] private AudioClip _checkpointSet;

    public void ReturnPlayerOnSpawn()
    {
        _characterController.Motor.SetPosition(_spawnPoint.position);
    }
    
    public void SetCheckpoint(Vector3 _position)
    {
        _spawnPoint.position = _position;
        MainAudioManager.instance.PlayMainAudioSourceClipOneShot(_checkpointSet);
    }
}
