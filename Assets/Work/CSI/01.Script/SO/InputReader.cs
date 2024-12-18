using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static MainControls;
[CreateAssetMenu(fileName = "InputReader", menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public Vector2 InputVector { get; private set; }

    public event Action<Vector2> OnMoveEvent;
    public event Action OnJumpEvent;
    
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
        Debug.Log(InputVector);
        OnMoveEvent?.Invoke(InputVector);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(!context.performed) return;
        OnJumpEvent?.Invoke();  
    }
}
