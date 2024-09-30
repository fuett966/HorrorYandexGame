using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class PawTrigger : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject _preAttack;
    [SerializeField] private GameObject _paw;
    [SerializeField] private GameObject _pawVFX;
    
    [Header("PreAttack")]
    [SerializeField]private float _pawPreAttackMoveTime = 0.7f;
    [SerializeField] private float _preAttackWaitTime=1.5f;
    
    [Header("PostAttack")]
    [SerializeField]private float _pawPostAttackMoveTime = 1.5f;
    [SerializeField] private float _postAttackWaitTime=1f;

    private bool _allowAttack = false;
    private float _preAttackTimerTemp;


    private void OnEnable()
    {
        BeatManager.OnPulse += Attack;
    }

    private void OnDisable()
    {
        BeatManager.OnPulse -= Attack;
    }

    private void Start()
    {
        PreAttack();
    }

    private void PreAttack()
    {
        _preAttack.SetActive(true);
        StartCoroutine(PreAttackTimer());
    }

    IEnumerator PreAttackTimer()
    {
        yield return new WaitForSeconds(_preAttackWaitTime);
        _allowAttack = true;
    }

    private void Attack()
    {
        if (!_allowAttack)
        {
            return;
        }
        _allowAttack = false;
        _preAttack.SetActive(false);
        _paw.SetActive(true);
        _pawVFX.SetActive(true);
        _paw.transform.DOMoveY(_paw.transform.position.y+17f,_pawPreAttackMoveTime).SetEase(Ease.Linear).OnComplete(() =>
        {
            StartCoroutine(PostAttackTimer());
        });
    }
    IEnumerator PostAttackTimer()
    {
        yield return new WaitForSeconds(_postAttackWaitTime);
        PostAttack();
    }

    private void PostAttack()
    {
        _paw.transform.DOMoveY(_paw.transform.position.y-17f,_pawPostAttackMoveTime).SetEase(Ease.Linear).OnComplete(() =>
        {
            _preAttack.SetActive(false);
            _paw.SetActive(false);
            _pawVFX.SetActive(false);
            Destroy(gameObject,2f);
        });
    }
}
