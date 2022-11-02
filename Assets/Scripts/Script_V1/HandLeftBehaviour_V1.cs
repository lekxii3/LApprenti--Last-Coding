using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandLeftBehaviour_V1 : MonoBehaviour
{
    [SerializeField] InputActionAsset PlayerController;
    InputAction _inputActionMenuButton;
    public delegate void LeftControllerSignal();
    public static LeftControllerSignal MenuButtonActivate;
    public static LeftControllerSignal MenuButtonDeactivate;
    public GameObject Canvas;
    bool _Retouch;

    private void OnEnable()
    {
        HandLeftBehaviour_V1.MenuButtonActivate += ActionMenuButtonActivate;
        //HandLeftBehaviour_V1.MenuButtonDeactivate += ActionMenuButtonDeactivate;
    }
    private void OnDisable()
    {
        HandLeftBehaviour_V1.MenuButtonActivate -= ActionMenuButtonActivate;
        //HandLeftBehaviour_V1.MenuButtonDeactivate -= ActionMenuButtonDeactivate;
    }
    void Update()
    {
        MenuButton();
    }

    void MenuButton()
    {
        var _controllerActionMap = PlayerController.FindActionMap("XRI LeftHand Interaction");
        _inputActionMenuButton = _controllerActionMap.FindAction("Start");
        _inputActionMenuButton.performed += MenuActivate;
        //_inputActionMenuButton.canceled += MenuDeactivate;
    }
    void MenuActivate(InputAction.CallbackContext context)
    {
        MenuButtonActivate?.Invoke();
    }
    void MenuDeactivate(InputAction.CallbackContext context)
    {
        MenuButtonDeactivate?.Invoke();
    }

    void ActionMenuButtonActivate()
    {
        _Retouch=!_Retouch;
        if (_Retouch==false)
        {
            //Debug.Log("Menu Activate");
            Canvas.SetActive(true);
        }
        else
        {
            //Debug.Log("Menu Deactivate");
            Canvas.SetActive(false);
        }
        
    }
    void ActionMenuButtonDeactivate()
    {
        
    }
}
