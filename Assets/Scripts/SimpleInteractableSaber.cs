using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleInteractableSaber : MonoBehaviour
{
    [SerializeField] private XRSimpleInteractable _simple;
    [SerializeField] private bool isUsing;
    private void OnEnable()
    {
        _simple.selectEntered.AddListener(SnapToInteractor);
        _simple.hoverEntered.AddListener(MessageLog);
    }
    private void OnDisable()
    {
        _simple.selectExited.RemoveListener(SnapToInteractor);
        _simple.hoverExited.RemoveListener(MessageLog);
    }
    public void SnapToInteractor(SelectEnterEventArgs args) 
    {
        isUsing = true;
    }
    public void SnapToInteractor(SelectExitEventArgs args)
    {
        isUsing = false;
    }
    public void MessageLog(HoverEnterEventArgs args)
    {
        Debug.Log("touche enter");
    }
    public void MessageLog(HoverExitEventArgs args)
    {
        Debug.Log("touche exit");
    }
}
