using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerTest : MonoBehaviour
{

    bool coroutine;
    public  int count;

    private void Start()
    {
        coroutine = true;
    }

    private void Update()
    {
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        coroutine=false;
        count++;
        yield return new WaitForSeconds(5);
        coroutine=true;
    }
}
