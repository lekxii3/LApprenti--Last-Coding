using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateFollow : MonoBehaviour
{
    public Transform cubeTarget;

    // Update is called once per frame
    void Update()
    {
        Quaternion rotationFollow = Quaternion.Euler(cubeTarget.transform.rotation.eulerAngles.x,cubeTarget.transform.rotation.eulerAngles.y, cubeTarget.transform.rotation.eulerAngles.z);

        transform.rotation = Quaternion.Slerp(transform.rotation,rotationFollow,1f);

        Debug.Log(transform.rotation);
    }
}
