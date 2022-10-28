using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SaberBehaviour_V1 : MonoBehaviour
{
    LayerMask _BlasterLayerMask = 8;
    private ParticleCollisionEvent[] _collisionPos;
    [SerializeField] GameObject _saberPrefabsDefense;
    Vector3 _targetposBlasterValue;
    [SerializeField] bool _contactBlaster;
    void Start()
    {
         
    }

    private void Update()
    {            
            SaberRotate();
        
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == _BlasterLayerMask)
        {
            _contactBlaster = true;
            var array = new ParticleCollisionEvent[other.GetComponent<ParticleSystem>().GetSafeCollisionEventSize()];
            int count = other.GetComponent<ParticleSystem>().GetCollisionEvents(gameObject, array);
            
            for(int i = 0; i < array.Length; i++)
            {
                var _pos = array[i].intersection;
                _targetposBlasterValue = _pos - _saberPrefabsDefense.transform.localPosition;               
            }
        }
        
    }   

    void SaberRotate()
    {        
        float angle = Mathf.Atan2(_targetposBlasterValue.y, _targetposBlasterValue.x) * Mathf.Rad2Deg-90;
        Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
        _saberPrefabsDefense.transform.rotation = Quaternion.Slerp(_saberPrefabsDefense.transform.rotation, angleAxis, 0.1f);
    }
   
}
