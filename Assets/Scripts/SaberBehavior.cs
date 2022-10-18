using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberBehavior : MonoBehaviour
{
    private List<FXBlasterBehaviour> _ListBlaster = new List<FXBlasterBehaviour>();
    void Start()
    {        
        var _foundFXBlaster = FindObjectsOfType<FXBlasterBehaviour>();
        foreach (var _obj in _foundFXBlaster)
        {
            _ListBlaster.Add(_obj);
            Debug.Log(_ListBlaster.IndexOf(_obj));
        }
        
    }

    private void OnParticleCollision(GameObject other)
    {
        var GetScript = other.GetComponentInChildren<ParticleSystem>().collision;
        GetScript.bounce = 1;
        GetScript.dampen = 0;
        GetScript.lifetimeLoss = 0.5f;
        
    }
}
