using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private SkinSO skinInfo;
    [SerializeField] private Color _pressedColor;
    [SerializeField] private Color _normalColor;
    private bool _isPressed = false;
    


    public void SetPressed(bool pressed)
    {
        _isPressed = pressed;
        if (pressed)
        {

        }
    }
}
