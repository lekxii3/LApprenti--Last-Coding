using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaberBehavior : MonoBehaviour
{
    private List<FXBlasterBehaviour> _ListBlaster = new List<FXBlasterBehaviour>();
    FXBlasterBehaviour _blasterBehaviourScriptAccess;
    public bool collisionOnSaber;
    private LayerMask _environnementMask = 6;

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
        if (other.layer == _environnementMask)
        {
            collisionOnSaber = true;
            Debug.Log(other.name);
            _blasterBehaviourScriptAccess = other.GetComponent<FXBlasterBehaviour>();   
            
        }       
    }

    /*private void LateUpdate()
    {
        if (collisionOnSaber == true)
        {
            var Get = _blasterBehaviourScriptAccess;
            int _numBlasterDeviated = Get._particlBlaster1.GetParticles(Get.m_blaster);
            float _drift = 1f;
            for (int i = 0; i < _numBlasterDeviated; i++)
            {
                _blasterBehaviourScriptAccess.m_blaster[i].velocity += Vector3.up * _drift;
            }
            Get._particlBlaster1.SetParticles(Get.m_blaster, _numBlasterDeviated);
            collisionOnSaber = false;
        }
    }*/




























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
