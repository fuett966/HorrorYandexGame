using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private SkinSO skinInfo;
    [SerializeField] private Color _pressedColor;
    [SerializeField] private Color _normalColor;
    [SerializeField] private Image _image;
    private bool _isPressed = false;


    public void ChangeContent(SkinSO info)
    {
        skinInfo = info;
        _image.sprite = skinInfo.icon;
    }

    public void SetPressed(bool pressed)
    {
        _isPressed = pressed;
        if (pressed)
        {

        }
    }
}
