using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class testXRsimple : MonoBehaviour
{
    public XRSimpleInteractable interactable;
    MeshRenderer _meshRenderer;
    MeshRenderer _saberDefenseMeshRender;
    private Rigidbody _rb;
    private GameObject RightHandInteractor;
    public GameObject saberDefense;
    public GameObject saberCollider;
    bool isUsing;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _saberDefenseMeshRender = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {        
        interactable.selectEntered.AddListener(TestGrabEnter);
        interactable.selectExited.AddListener(TestGrabExit);
    }
    private void OnDisable()
    {        
        interactable.selectEntered.RemoveListener(TestGrabEnter);
        interactable.selectExited.RemoveListener(TestGrabExit);
    }

    
    private void TestGrabEnter(SelectEnterEventArgs args)
    {
        isUsing = true;
        _rb.useGravity = false;
        _rb.isKinematic = true;
        RightHandInteractor = args.interactorObject.transform.gameObject;
    }
    private void TestGrabExit(SelectExitEventArgs args)
    {
        isUsing = false;
        _rb.useGravity = true;
        _rb.isKinematic = false;
    }

    private void Update()
    {
        if (isUsing)
        {
            //_meshRenderer.enabled = false;
            //_saberDefenseMeshRender.enabled = true;
            transform.position = RightHandInteractor.transform.position;
            transform.rotation = RightHandInteractor.transform.rotation;
            saberDefense.transform.position = transform.position;
            saberDefense.transform.rotation = transform.rotation;
            saberCollider.transform.position = transform.position;
            saberCollider.transform.rotation = transform.rotation;
           
        }
    }
}
