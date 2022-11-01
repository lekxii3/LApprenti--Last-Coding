using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPedale : MonoBehaviour
{
    // R�f�rence vers la p�dale qui doit rester immobile
    public Transform platform;

    // Vitesse de rotation du p�dalier sur son axe Z
    public float zRotationSpeed = 0.5f;

    void Update()
    {
        transform.rotation = transform.rotation*(Quaternion.AngleAxis(zRotationSpeed,Vector3.forward));

        platform.rotation = Quaternion.identity;
    }
}
