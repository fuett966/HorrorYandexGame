using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioManager : MonoSingleton<MainAudioManager>
{
    [SerializeField] private AudioSource _mainAudioSource; 

    public void PlayMainAudioSourceClipOneShot(AudioClip _clip)
    {
        _mainAudioSource.PlayOneShot(_clip);
    }

    public void PlayMainSourceAudio()
    {
        _mainAudioSource.Play();
    }
    public void PlayMainSourceAudio(AudioClip _clip)
    {
        
        _mainAudioSource.clip = _clip;
        _mainAudioSource.Play();
    }
    public void PauseMainSourceAudio()
    {
        _mainAudioSource.Pause();
    }

}
