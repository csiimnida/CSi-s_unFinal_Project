using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static MainControls;
[CreateAssetMenu(fileName = "InputReader", menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public Vector2 InputVector { get; private set; }
    public Vector2 MouseInputValue { get; private set; }

    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnMouseMoveEvent;
    public event Action OnJumpEvent;
    public event Action<Vector2> OnMouseClickEvent;
    public event Action<Vector2> OnMouseClickCancelEvent;
    public event Action<Vector2> OnMousePosEvent;
    
    private MainControls _playerControls;
    
    private void OnEnable()
    {
        if(_playerControls == null)
        {
            _playerControls = new MainControls();
            _playerControls.Player.AddCallbacks(this);
        }
        _playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Player.Disable();
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        InputVector = context.ReadValue<Vector2>();
        OnMoveEvent?.Invoke(InputVector);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(!context.performed) return;
        OnJumpEvent?.Invoke();  
        Debug.Log("Jump");
    }

    public void OnMouseMove(InputAction.CallbackContext context)
    {
        if(context.started) return;
        //Debug.Log(context.ReadValue<Vector2>());
        OnMouseMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMousePos(InputAction.CallbackContext context)
    {
        MouseInputValue = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        OnMousePosEvent?.Invoke(MouseInputValue);
    }

    public void OnMouseLeftClick(InputAction.CallbackContext context)
    {
        if (context.started) OnMouseClickEvent?.Invoke(MouseInputValue);
        else if (context.canceled) OnMouseClickCancelEvent?.Invoke(MouseInputValue);
    }
}
