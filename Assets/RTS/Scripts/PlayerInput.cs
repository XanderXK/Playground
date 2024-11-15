using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RTS
{
    public class PlayerInput : MonoBehaviour, RTSControls.IMainActions
    {
        public Vector2 MousePosition { get; private set; }
        public bool Selecting { get; private set; }
        public bool Adding { get; private set; }
        public event Action OnPlayerMove;
        public event Action OnPlayerSelectStart;
        public event Action OnPlayerSelectEnd;


        private RTSControls mainControls;


        private void Awake()
        {
            mainControls = new RTSControls();
            mainControls.Main.SetCallbacks(this);
        }

        private void OnEnable()
        {
            mainControls.Enable();
        }

        private void Update()
        {
            MousePosition = Mouse.current.position.ReadValue();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }

            OnPlayerMove?.Invoke();
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnPlayerSelectStart?.Invoke();
                Selecting = true;
            }

            if (context.canceled)
            {
                OnPlayerSelectEnd?.Invoke();
                Selecting = false;
            }
        }

        public void OnAdd(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Adding = true;
            }

            if (context.canceled)
            {
                Adding = false;
            }
        }

        private void OnDisable()
        {
            mainControls.Disable();
        }

    }
}
