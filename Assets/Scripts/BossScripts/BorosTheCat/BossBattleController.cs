using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BossBattle
{
    public class BossBattleController : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private bool _bombAttack;
        [SerializeField] private bool _pawAttack;
        [Header("Bombs")] [SerializeField] private Transform _bombSpawnTransform;
        [SerializeField] private GameObject _bomb;
        [SerializeField] private float _curvePover;
        [SerializeField] private float _flyTime;
        [SerializeField] private int _shootAtBit = 5;
        [Header("Paws")] [SerializeField] private GameObject _paw;
        [SerializeField] private GameObject _spawnPlane;

        private int _bitCount = 0;

        private void Awake()
        {
            BeatManager.OnPulse += () =>
            {
                _bitCount += 1;
                if (_bitCount % _shootAtBit == 0)
                {
                    if (_bombAttack)
                    {
                        ShootBomb();
                    }

                    if (_pawAttack)
                    {
                        PawAttack();
                    }
                }
            };
        }
        private void ShootBomb()
        {
            var bomb = Instantiate(_bomb, _bombSpawnTransform.position, Quaternion.identity);
            Vector3 previousPosition = bomb.transform.position;
            bomb.transform.DOJump(_playerTransform.position, _curvePover, 0, _flyTime).SetEase(Ease.Linear).OnUpdate(
                () =>
                {
                    Vector3 direction = bomb.transform.position - previousPosition;
                    if (direction != Vector3.zero)
                    {
                        Quaternion rotation = Quaternion.LookRotation(direction);
                        bomb.transform.rotation = rotation;
                    }

                    previousPosition = bomb.transform.position;
                });
        }

        private void PawAttack()
        {
            Vector3 spawnPosition = new Vector3(_playerTransform.position.x, _spawnPlane.transform.position.y + 1f,
                _playerTransform.position.z);
            GameObject _pawTemp = Instantiate(_paw, spawnPosition, Quaternion.identity);
        }
    }
}