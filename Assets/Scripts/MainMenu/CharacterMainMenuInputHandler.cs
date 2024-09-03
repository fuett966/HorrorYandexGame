using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMainMenuInputHandler : MonoBehaviour
{
    [SerializeField] private RotationHandler rotationHandler;
     

    void Update()
    {
        HandleMouseInput();
        HandleTouchInput();
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            rotationHandler.RotateObject(mouseX, 0);
        }
    }

    void HandleTouchInput()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchDeltaPosition = touch.deltaPosition;

            rotationHandler.RotateObject(touchDeltaPosition.x, touchDeltaPosition.y);
        }
    }
}
