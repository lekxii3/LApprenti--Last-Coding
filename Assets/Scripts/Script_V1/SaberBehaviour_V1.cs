using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberBehaviour_V1 : MonoBehaviour
{
    LayerMask _BlasterLayerMask = 8;
    public delegate void CollisionBlasterSaber();
    public static CollisionBlasterSaber CollisionBlasterSaberSignal;
    FXBlasterBehaviour_V1 _BlasterBehaviourScriptAccess;
    [SerializeField] GameObject _saberPrefabs;

    private void OnEnable()
    {
        FXBlasterBehaviour_V1.positionBlasterSignal += SaberRotate;
    }
    private void OnDisable()
    {
        FXBlasterBehaviour_V1.positionBlasterSignal -= SaberRotate;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == _BlasterLayerMask)
        {
            CollisionBlasterSaberSignal?.Invoke();           
        }
    }
    void SaberRotate()
    {
        _BlasterBehaviourScriptAccess = FindObjectOfType<FXBlasterBehaviour_V1>();
        
        foreach(Vector3 pos in _BlasterBehaviourScriptAccess._positionBlaster)
        {
            _saberPrefabs.transform.position = pos;
        }
        
    }
}
