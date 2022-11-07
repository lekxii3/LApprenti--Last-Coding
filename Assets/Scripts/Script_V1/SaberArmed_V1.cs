using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberArmed_V1 : MonoBehaviour
{
    public GrabSaber_V1 GrabSaber_V1ScriptAccess;
    [SerializeField] Transform _SaberLaserPrefabTransform;
    [SerializeField] GameObject _SaberLaserPrefab;
    public bool armedBool;
    bool _autorized;
    bool _useButton=true;
    float _timer;
    Vector3 _SaberColliderSizeArmed = new Vector3(0.07258129f, 1, 0.1071429f);
    Vector3 _SaberColliderCenterArmed = new Vector3(0, 0.3347404f, 0);
    Vector3 _SaberColliderSizeDearmed = new Vector3(0.07258129f, 0.3351443f, 0.1071429f);
    Vector3 _SaberColliderCenterDearmed = new Vector3(0, 0.0308151f, -6.661338e-16f);


    private void Start()
    {
        
    }
    private void OnEnable()
    {
        HandRightBehaviour_V1.SecondaryButtonArmedActivate += Armed;
        //HandRightBehaviour_V1.SecondaryButtonArmedDeactivate += Dearmed;
    }

    private void OnDisable()
    {
        HandRightBehaviour_V1.SecondaryButtonArmedActivate -= Armed;
        //HandRightBehaviour_V1.SecondaryButtonArmedDeactivate -= Dearmed;
    }

    private void FixedUpdate()
    {
        ArmedDearmed();
    }

    void Armed()
    {
        if (_useButton)
        {
            if (armedBool == false)
            {
                _autorized = true;
                armedBool = true;
            }
            else
            {
                _autorized = true;
                armedBool = false;
            }
        }
        
    }

    /*void Dearmed()
    {
        
    }*/

    void ArmedDearmed()
    {
        if (GrabSaber_V1ScriptAccess.isUsing == true)
        {
            if (armedBool == true)
            {
                if (_autorized)
                {
                    _useButton = false;
                    var _SaberLaserPrefabColliderAccess = _SaberLaserPrefab.GetComponent<BoxCollider>();
                    _SaberLaserPrefabColliderAccess.size = _SaberColliderSizeDearmed;
                    _SaberLaserPrefabColliderAccess.center = _SaberColliderCenterDearmed;
                    Vector3 _armed = Vector3.one;
                    float _lerpFraction = 0;
                    _lerpFraction += (Time.deltaTime) * 1.5f;
                    _SaberLaserPrefabTransform.localScale = Vector3.SmoothDamp(_SaberLaserPrefabTransform.localScale, _armed, ref _armed, _lerpFraction);
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
                    var _SaberLaserPrefabColliderAccess = _SaberLaserPrefab.GetComponent<BoxCollider>();
                    _SaberLaserPrefabColliderAccess.size = _SaberColliderSizeArmed;
                    _SaberLaserPrefabColliderAccess.center = _SaberColliderCenterArmed;
                    Vector3 _dearmed = new Vector3(1, 0, 1);
                    float _lerpFraction = 0;
                    _lerpFraction += (Time.deltaTime) * 1.5f;
                    _SaberLaserPrefabTransform.localScale = Vector3.SmoothDamp(_SaberLaserPrefabTransform.localScale, _dearmed, ref _dearmed, _lerpFraction);
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
    }
}
