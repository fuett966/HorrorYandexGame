using UnityEngine;
using UnityEngine.EventSystems;

public class UnityEditorScreenSwipeInput : MonoBehaviour
{
    private Vector3 _lastPos, _deltaPos;
    [Range(0, 2)] public float sensitivity;
    private bool _mouseOverUI;

    private void Awake()
    {
        
    }

    void Update()
    {
#if (UNITY_EDITOR)
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == true)
            {
                _mouseOverUI = true;
            }

            _lastPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _mouseOverUI = false;
        }

        if (!_mouseOverUI)
        {
            if (Input.GetMouseButton(0))
            {
                _deltaPos = _lastPos - Input.mousePosition;
                Vector2 tempLook = new Vector2(Mathf.Lerp(InputManager.instance.CameraInput.y,
                    -_deltaPos.x * sensitivity, 15 * Time.deltaTime), Mathf.Lerp(InputManager.instance.CameraInput.x,
                    -_deltaPos.y * sensitivity, 15 * Time.deltaTime));
            }
            else
            {
                //InputManager.instance.CameraInput = Vector2.zero;
            }

            _lastPos = Input.mousePosition;
        }
#endif

    }
}