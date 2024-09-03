using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerColliderEvent : MonoBehaviour
{
    [SerializeField] private string _triggerTag;
    [SerializeField] private string _newSceneName = "";

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.CompareTag(_triggerTag))
        {
            LevelController.instance.SetEnabledCharacterMovement(false);
            
            if (_newSceneName == "")
            {
                LevelLoader.instance.LoadNewSceneAsync();
            }
            else
            {
                LevelLoader.instance.LoadNewSceneAsync(_newSceneName);
            }
        }
    }
}