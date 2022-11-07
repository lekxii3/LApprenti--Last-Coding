using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandRightBehaviour_V1 : MonoBehaviour
{
    [SerializeField] InputActionAsset PlayerController;
    InputAction _inputActionPrimaryButtonProtection;
    InputAction _inputActionSecondaryButtonArmed;
    public delegate void RightControllerSignal();
    public static RightControllerSignal PrimaryButtonProtectionActivate;
    public static RightControllerSignal PrimaryButtonProtectionDeactivate;
    public static RightControllerSignal SecondaryButtonArmedActivate;
    public static RightControllerSignal SecondaryButtonArmedDeactivate;

    void Update()
    {
        PrimaryButtonPressed();
        SecondButtonPressed();
    }

    void PrimaryButtonPressed()
    {
        var _controllerActionMap = PlayerController.FindActionMap("XRI RightHand Interaction");
        _inputActionPrimaryButtonProtection = _controllerActionMap.FindAction("Protection");
        _inputActionPrimaryButtonProtection.performed += ProtectionActivate;
        _inputActionPrimaryButtonProtection.canceled += ProtectionDesactivate;
    }

    void ProtectionActivate(InputAction.CallbackContext context)
    {
        PrimaryButtonProtectionActivate?.Invoke(); //look at to script SaberBehaviour
    }

    void ProtectionDesactivate(InputAction.CallbackContext context)
    {
        PrimaryButtonProtectionDeactivate?.Invoke(); //look at to script SaberBehaviour
    }

    void SecondButtonPressed()
    {
        var _controllerActionMap = PlayerController.FindActionMap("XRI RightHand Interaction");
        _inputActionSecondaryButtonArmed = _controllerActionMap.FindAction("Armed");
        _inputActionSecondaryButtonArmed.performed += ArmedActivate;
        _inputActionSecondaryButtonArmed.canceled += ArmedDeactivate;
    }

    void ArmedActivate(InputAction.CallbackContext context)
    {
        SecondaryButtonArmedActivate?.Invoke();
    }

    void ArmedDeactivate(InputAction.CallbackContext context)
    {
        SecondaryButtonArmedDeactivate?.Invoke();
    }
}
