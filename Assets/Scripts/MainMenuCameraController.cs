using DG.Tweening;
using System;
using UnityEngine;

[Serializable]
public class MainMenuCameraState
{
    public Transform CameraTransform;
}
public class MainMenuCameraController : MonoBehaviour
{
    [SerializeField] private MainMenuCameraState[] _cameraStates;
    [SerializeField] private MainMenuCameraState _currentState;

    [SerializeField] private float _moveTime = 1f;
    private bool _isMove = false;

    public void ChangeCameraPosition(int _id)
    {
        MoveCamera(_cameraStates[_id].CameraTransform, _moveTime);
    }

    private void MoveCamera(Transform _cameraTransform, float _time)
    {
        if (_isMove)
        {
            return;
        }

        _isMove = true;
        transform.DOMove(_cameraTransform.position, _time);
        transform.DORotate(_cameraTransform.eulerAngles, _time).OnComplete(() =>
        {
            _isMove = false;
        });
    }

}
