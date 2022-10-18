using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaberBehavior : MonoBehaviour
{
    private List<FXBlasterBehaviour> _ListBlaster = new List<FXBlasterBehaviour>();
    FXBlasterBehaviour _blasterBehaviourScriptAccess;
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
        if (other.layer == 1)
        {
                var Get = other.GetComponent<FXBlasterBehaviour>();
                int _numBlasterDeviated = Get._particlBlaster1.GetParticles(Get.m_blaster);                
                float _drift = 1f;
                for (int i = 0; i < _numBlasterDeviated; i++)
                {
                    _blasterBehaviourScriptAccess.m_blaster[i].velocity += Vector3.up * _drift;
                }
                Get._particlBlaster1.SetParticles(Get.m_blaster, _numBlasterDeviated);
            
        }
       
    }




























    /*private void OnParticleCollision(GameObject other)
    {
        var GetScript = other.GetComponentInChildren<ParticleSystem>().collision;

        if(other.layer == 1)
        {
            GetScript.bounce = 1;
            GetScript.dampen = 0;
            GetScript.lifetimeLoss = 0.5f;
        }
        else if(other)
        {
            GetScript.bounce = 0;
            GetScript.dampen = 1;
            GetScript.lifetimeLoss = 1f;
        }
                
    }*/



}
