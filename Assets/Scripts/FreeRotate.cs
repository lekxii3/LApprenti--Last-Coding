using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRotate : MonoBehaviour
{
    private Quaternion _LastParentRotation;
    [SerializeField] Transform _TransformParentFollow;
    float rotationX;
    float rotationZ;
    void Start()
    {
        _LastParentRotation = transform.parent.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localRotation = Quaternion.Inverse(transform.parent.localRotation)*_LastParentRotation*transform.localRotation;
        //_LastParentRotation=transform.parent.localRotation;
        rotationX = _TransformParentFollow.rotation.x;
        rotationZ = _TransformParentFollow.rotation.z;
        transform.position = _TransformParentFollow.position;
        transform.rotation = new Quaternion(rotationX, transform.rotation.y, rotationZ, transform.rotation.w);

    }
}
