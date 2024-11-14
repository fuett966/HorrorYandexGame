using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class InputManager : MonoSingleton<InputManager>
{
    private PlayerInput _input;

    public UnityEvent onJumpInputDown, onJumpInputUp;
    public UnityEvent onCrouchInputDown, onCrouchInputUp;
    public UnityEvent onInteractInputDown, onInteractInputUp;
    public UnityEvent onFireInputDown, onFireInputUp;
    public UnityEvent onADSInputDown, onADSInputUp;
    public UnityEvent toggleInventoryUI;
    public UnityEvent onReloadInputDown, onReloadInputUp;

    private Vector2 moveInput, cameraInput;
    private bool noClip;
    private bool charge;
    private bool sprint;
    private bool jump;
    private bool crouch;
    private bool interact;
    private bool fire;
    private bool aim;
    private bool reload;
    private bool inventory;
    private bool menu;
    private bool dance;

    public bool NoClip { get => noClip; }
    public bool Charge { get => charge;  }
    public bool Sprint { get => sprint; }
    public bool Jump { get => jump; }
    public bool Crouch { get => crouch; }
    public bool Interact { get => interact; }
    public bool Fire { get => fire; }
    public bool Aim { get => aim; }
    public bool Reload { get => reload; }
    public bool Inventory { get => inventory; }
    public bool Menu { get => menu; }
    public Vector2 MoveInput { get => moveInput; }
    public Vector2 CameraInput { get => cameraInput; }
    public bool Dance { get => dance;  }

    private void OnEnable()
    {
        _input = new PlayerInput();
        _input.Enable();


        
        _input.Player.Move.started += OnMove;
        _input.Player.Move.performed += OnMove;
        _input.Player.Move.canceled += OnMove;

        _input.Player.Look.started += OnLook;
        _input.Player.Look.performed += OnLook;
        _input.Player.Look.canceled += OnLook;

        _input.Player.Jump.started += OnJump;
        _input.Player.Jump.canceled += OnJump;
        
        _input.Player.Dance.started += OnDance;
        _input.Player.Dance.canceled += OnDance;
        _input.Player.Dance.performed += OnDance;
        
        _input.Player.Fire.started += OnFire;
        _input.Player.Fire.canceled += OnFire;

        _input.Player.Charge.started += OnCharge;
        _input.Player.Charge.performed += OnCharge;
        _input.Player.Charge.canceled += OnCharge;

        _input.Player.Interact.started += OnInteract;
        _input.Player.Interact.canceled += OnInteract;

        _input.Player.Crouch.started += OnCrouch;
        _input.Player.Crouch.canceled += OnCrouch;

        _input.Player.Sprint.started += OnSprint;
        _input.Player.Sprint.canceled += OnSprint;

        _input.Player.NoClip.performed += OnNoClip;

        

    }
    private void OnDisable()
    {
        _input.Player.Move.started -= OnMove;
        _input.Player.Move.performed -= OnMove;
        _input.Player.Move.canceled -= OnMove;

        _input.Player.Look.started -= OnLook;
        _input.Player.Look.performed -= OnLook;
        _input.Player.Look.canceled -= OnLook;

        _input.Player.Jump.started -= OnJump;
        _input.Player.Jump.canceled -= OnJump;
        
        _input.Player.Dance.started -= OnDance;
        _input.Player.Dance.canceled -= OnDance;
        _input.Player.Dance.performed -= OnDance;
        
        _input.Player.Fire.started -= OnFire;
        _input.Player.Fire.canceled -= OnFire;

        _input.Player.Charge.started -= OnCharge;
        _input.Player.Charge.performed -= OnCharge;
        _input.Player.Charge.canceled -= OnCharge;

        _input.Player.Interact.started -= OnInteract;
        _input.Player.Interact.canceled -= OnInteract;

        _input.Player.Crouch.started -= OnCrouch;
        _input.Player.Crouch.canceled -= OnCrouch;

        _input.Player.Sprint.started -= OnSprint;
        _input.Player.Sprint.canceled -= OnSprint;

        _input.Player.NoClip.performed -= OnNoClip;

        _input.Disable();
    }


#if ENABLE_INPUT_SYSTEM && !UNITY_ANDROID
    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    private void OnLook(InputAction.CallbackContext context)
    {
        cameraInput = context.ReadValue<Vector2>();
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if(context.canceled)jump = false;
        else if(context.started)jump = true;
    }
    
    private void OnFire(InputAction.CallbackContext context)
    {
        if(context.canceled)fire = false;
        else if(context.started)fire = true;
    }

    private void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.canceled) crouch = false;
        else if (context.started) crouch = true;
    }

    private void OnNoClip(InputAction.CallbackContext context)
    {
        noClip = !noClip;
    }

    private void OnCharge(InputAction.CallbackContext context)
    { 
        if(context.canceled)charge = false;
        else if(context.started)charge = true;
    }
    private void OnInteract(InputAction.CallbackContext context)
    {
        if (context.canceled) interact = false;
        else if (context.started) interact = true;
    }
    private void OnSprint(InputAction.CallbackContext context)
    {
        if (context.canceled) sprint = false;
        else if (context.started) sprint = true;
    }
    private void OnDance(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            dance = true;
        }

        else if (context.canceled)
        {
            dance = false;
        }
        
    }
#endif

    public void OnMove(Vector2 value)
    {
        moveInput = value;
    }
    public void OnLook(Vector2 value)
    {
        cameraInput = value;
    }
    public void OnJump(bool value)
    {
        jump = value;
    }

    public void OnCrouch(bool value)
    {
        crouch = value;
    }

    public void OnNoClip(bool value)
    {
        noClip = value;
    }

    public void OnCharge(bool value)
    {
        charge = value;
    }
    public void OnInteract(bool value)
    {
        interact = value;
    }
    public void OnSprint(bool value)
    {
        sprint = value;
    }

    public void ADSInputDown()
    {
        onADSInputDown.Invoke();
        aim = true;
    }

    public void ADSInputUp()
    {
        onADSInputUp.Invoke();
        aim = false;
    }

    public void ReloadInputDown()
    {
        onReloadInputDown.Invoke();
        reload = true;
    }

    public void ReloadInputUp()
    {
        onReloadInputUp.Invoke();
        reload = false;
    }

    public void FireInputDown()
    {
        onFireInputDown.Invoke();
        fire = true;
    }

    public void FireInputUp()
    {
        onFireInputUp.Invoke();
        fire = false;
    }

    public void InteractInputDown()
    {
        onInteractInputDown.Invoke();
        interact = true;
    }

    public void InteractInputUp()
    {
        onInteractInputUp.Invoke();
        interact = false;
    }

    public void CrouchInputDown()
    {
        onCrouchInputDown.Invoke();
        crouch = true;
    }

    public void CrouchInputUp()
    {
        onCrouchInputUp.Invoke();
        crouch = false;
    }

    public void JumpInputDown()
    {
        onJumpInputDown.Invoke();
        jump = true;
    }

    public void JumpInputUp()
    {
        onJumpInputUp.Invoke();
        jump = false;
    }

    public void ToggleInventoryUI()
    {
        toggleInventoryUI.Invoke();
    }

}