using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabSaber_V1 : MonoBehaviour
{
    public XRSimpleInteractable interactable;
    private Rigidbody _rb;
    public GameObject RightHandInteractor;
    public GameObject saberDefense;
    public GameObject saberCollider;
    public bool isUsing;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        interactable.selectEntered.AddListener(GrabEnter);
        interactable.selectExited.AddListener(GrabExit);
    }
    private void OnDisable()
    {
        interactable.selectEntered.RemoveListener(GrabEnter);
        interactable.selectExited.RemoveListener(GrabExit);
    }


    private void GrabEnter(SelectEnterEventArgs args)
    {
        isUsing = true;
        _rb.useGravity = false;
        _rb.isKinematic = true;
        RightHandInteractor = args.interactorObject.transform.gameObject;
    }
    private void GrabExit(SelectExitEventArgs args)
    {
        isUsing = false;
        _rb.useGravity = true;
        _rb.isKinematic = false;

    }

    private void Update()
    {
        if (isUsing)
        {
            transform.position = RightHandInteractor.transform.position;
            transform.rotation = RightHandInteractor.transform.rotation;
            saberDefense.transform.position = transform.position;
            saberCollider.transform.position = transform.position;
            saberCollider.transform.rotation = transform.rotation;
        }
        if (isUsing == false)
        {
            transform.position = transform.position;
            transform.rotation = transform.rotation;
            saberDefense.transform.position = transform.position;
            saberCollider.transform.position = transform.position;
            saberCollider.transform.rotation = transform.rotation;
        }        
    }
}
