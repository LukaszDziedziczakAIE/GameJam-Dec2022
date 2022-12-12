using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    Controls controls;

    public event Action LeftMouseEvent;
    public event Action RightMouseEvent;
    public Vector2 CameraMovement { get; private set; }


    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }

    public void OnCameraControl(InputAction.CallbackContext context)
    {
        CameraMovement = context.ReadValue<Vector2>();
    }

    public void OnLeftMouse(InputAction.CallbackContext context)
    {
        if (context.performed) LeftMouseEvent?.Invoke();
    }

    public void OnRightMouse(InputAction.CallbackContext context)
    {
        if (context.performed) RightMouseEvent?.Invoke();
    }
}
