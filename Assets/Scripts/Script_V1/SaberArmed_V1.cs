using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberArmed_V1 : MonoBehaviour
{
    [SerializeField] Transform _SaberLaserPrefab;
    bool _armedBool;
    bool _autorized;
    bool _useButton=true;
    float _timer;


    private void OnEnable()
    {
        HandRightBehaviour_V1.SecondaryButtonArmedActivate += Armed;
        HandRightBehaviour_V1.SecondaryButtonArmedDeactivate += Dearmed;
    }

    private void OnDisable()
    {
        HandRightBehaviour_V1.SecondaryButtonArmedActivate -= Armed;
        HandRightBehaviour_V1.SecondaryButtonArmedDeactivate -= Dearmed;
    }

    private void FixedUpdate()
    {
        if (_armedBool == true)
        {            
            if (_autorized)            
            {
                _useButton = false;
                Vector3 _armed = Vector3.one;
                float _lerpFraction = 0;
                _lerpFraction += (Time.deltaTime) * 1.5f;
                _SaberLaserPrefab.localScale = Vector3.SmoothDamp(_SaberLaserPrefab.localScale, _armed, ref _armed, _lerpFraction);
                Debug.Log("Armed");
                _timer += Time.deltaTime;

                if (_timer > 1.55f)
                {
                    _autorized = false;
                    _useButton = true;
                    _timer = 0;
                }
            }
        }
        else
        {
            
            if (_autorized)
            {
                _useButton = false;
                Vector3 _dearmed = new Vector3(1, 0, 1);
                float _lerpFraction = 0;
                _lerpFraction += (Time.deltaTime) * 1.5f;
                _SaberLaserPrefab.localScale = Vector3.SmoothDamp(_SaberLaserPrefab.localScale, _dearmed, ref _dearmed, _lerpFraction);
                Debug.Log("Dearmed");
                _timer += Time.deltaTime;

                if (_timer > 1.55f)
                {
                    _autorized = false;
                    _useButton = true;
                    _timer = 0;
                }
            }
        }
    }

    void Armed()
    {
        if (_useButton)
        {
            if (_armedBool == false)
            {
                _autorized = true;
                _armedBool = true;
            }
            else
            {
                _autorized = true;
                _armedBool = false;
            }
        }
        
    }

    void Dearmed()
    {
        
    }
}
