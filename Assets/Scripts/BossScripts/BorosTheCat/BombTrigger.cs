using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BombTrigger : MonoBehaviour
{
    public string TriggerTag;
    [SerializeField] private GameObject _effect;
    [SerializeField] private float _audioVolume;
    [SerializeField] private AudioClip _explodeClip;
    [SerializeField] private float _preExplodeTime = 0.6f;
    private bool _allowExplode = false;

    private void Awake()
    {
        _effect.SetActive(false);
    }

    private void Start()
    {
        BeatManager.OnPulse += Explode;
    }

    private void OnDestroy()
    {
        BeatManager.OnPulse -= Explode;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TriggerTag))
        {
            StartCoroutine(SetExplosive());
        }
    }

    IEnumerator SetExplosive()
    {
        yield return new WaitForSeconds(_preExplodeTime);
        _allowExplode = true;
    }

    private void Explode()
    {
        if (!_allowExplode)
        {
            return;
        }
        AudioSource.PlayClipAtPoint(_explodeClip, transform.position, _audioVolume);
        GameObject obj =  Instantiate(_effect, transform.position, Quaternion.identity);
        obj.SetActive(true);
        Destroy(obj,10f);
        Destroy(gameObject,0.1f);
    }
}
