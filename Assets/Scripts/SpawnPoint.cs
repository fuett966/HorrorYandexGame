using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController.Examples;

public class SpawnPoint : MonoBehaviour
{
    private bool _isActivated = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isActivated)
        {
            PlayerManager.instance.SetCheckpoint(transform.position);
            _isActivated = true;
        }
    }
}
