using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectTransformer : MonoBehaviour
{
    [SerializeField] private Vector3 _rotateVector;
    [SerializeField] private bool _isInfinitySpin;
    [SerializeField] private float _cooldownBetweenRotate;
    [SerializeField] private float _speedRotate;

    [SerializeField] private Vector3 _moveVector;
    [SerializeField] private float _cooldownBetweenMoves;
    [SerializeField] private float _timeMove;


    private void Start()
    {
        StartPhysics();
    }

    public void StartPhysics()
    {
        StartCoroutine(Rotate());
        //StartCoroutine(Move());
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(_rotateVector * _speedRotate);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.DOMove(_moveVector, _timeMove).OnComplete(
                () => { transform.DOLocalMove(-_moveVector, _timeMove); });
            yield return new WaitForSeconds(_timeMove * 2);
        }

    }
}