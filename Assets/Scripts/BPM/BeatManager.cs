using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoSingleton<BeatManager>
{
    [SerializeField] public float _bpm;
    [SerializeField] private AudioSource _audioSource;

    private float[] _spectrumData = new float[512];
    public float _threshold = 0.1f;

    private float _lastPeakTime = 0f;
    public float _minTimeBetweenBeats = 0.2f;


    public static event Action OnPulse;

    private void Awake()
    {
    }

    private void Update()
    {
        if (_audioSource.clip == null || !_audioSource.isPlaying || _bpm == 0)
            return;

        InvokePulse();
    }

    public void ActivatePulse()
    {
        OnPulse?.Invoke();
    }

    public void AnalyzeClip()
    {
        _bpm = UniBpmAnalyzer.AnalyzeBpm(_audioSource.clip);
        
        Debug.Log("AudioClip bpm: " + _bpm);
    }

    private void InvokePulse()
    {
        _audioSource.GetSpectrumData(_spectrumData, 0, FFTWindow.Blackman);

        float maxAmplitude = 0f;
        int maxIndex = 0;

        for (int i = 0; i < _spectrumData.Length; i++)
        {
            if (_spectrumData[i] > maxAmplitude)
            {
                maxAmplitude = _spectrumData[i];
                maxIndex = i;
            }
        }

        if (maxAmplitude > _threshold && Time.time - _lastPeakTime > _minTimeBetweenBeats)
        {
            _lastPeakTime = Time.time;
            Debug.Log("Detected beat at frequency index: " + maxIndex + " with amplitude: " + maxAmplitude);
            OnPulse?.Invoke();
        }
    }
}