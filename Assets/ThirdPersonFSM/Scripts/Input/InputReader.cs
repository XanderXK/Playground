using System;
using ThirdPersonFSM;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, ThirdPersonPlayerControls.IPlayerActions
{
    public Vector2 MoveValue { get; private set; }
    public bool IsAttacking { get; private set; }
    public bool IsBlocking { get; private set; }

    public event Action OnPlayerJump;
    public event Action OnPlayerDodge;
    public event Action OnPlayerSetTarget;
    public event Action OnPlayerCancelTarget;
    
    private ThirdPersonPlayerControls _playerControls;


    private void Start()
    {
        _playerControls = new ThirdPersonPlayerControls();
        _playerControls.Player.SetCallbacks(this);
        _playerControls.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveValue = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnPlayerJump?.Invoke();
        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnPlayerDodge?.Invoke();
        }
    }

    public void OnSetTarget(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnPlayerSetTarget?.Invoke();
        }
    }

    public void OnCancelTarget(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnPlayerCancelTarget?.Invoke();
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
    }

    private void OnDestroy()
    {
        _playerControls.Player.Disable();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsAttacking = true;
        }

        if (context.canceled)
        {
            IsAttacking = false;
        }
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsBlocking = true;
        }

        if (context.canceled)
        {
            IsBlocking = false;
        }
    }
}
