using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    float _timer;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        Debug.Log(_timer);
    }
}
