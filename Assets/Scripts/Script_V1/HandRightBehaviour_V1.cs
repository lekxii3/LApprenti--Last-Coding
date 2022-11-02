using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandRightBehaviour_V1 : MonoBehaviour
{
    [SerializeField] InputActionAsset PlayerController;
    InputAction _inputActionPrimaryButtonProtection;
    public delegate void RightControllerSignal();
    public static RightControllerSignal PrimaryButtonProtectionActivate;
    public static RightControllerSignal PrimaryButtonProtectionDeactivate;
    
    void Update()
    {
        PrimaryButtonPressed();
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
        PrimaryButtonProtectionActivate?.Invoke();
    }

    void ProtectionDesactivate(InputAction.CallbackContext context)
    {
        PrimaryButtonProtectionDeactivate?.Invoke();
    }
}
