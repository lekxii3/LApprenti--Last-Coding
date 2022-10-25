using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SaberBehaviour_V1 : MonoBehaviour
{
    LayerMask _BlasterLayerMask = 8;
    private ParticleCollisionEvent[] _collisionPos;
    [SerializeField] GameObject _saberPrefabs;
    Vector3 _targetposBlasterValue;
    [SerializeField] bool _contactBlaster;
    private Quaternion _LastParentRotation;
    void Start()
    {
        _LastParentRotation = transform.parent.localRotation;
    }

    private void Update()
    {
            FreeRotate();
            SaberRotate();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == _BlasterLayerMask)
        {
            _contactBlaster = true;
            var array = new ParticleCollisionEvent[other.GetComponent<ParticleSystem>().GetSafeCollisionEventSize()];
            int count = other.GetComponent<ParticleSystem>().GetCollisionEvents(gameObject, array);
            /*foreach(ParticleCollisionEvent item in array)
            {
                var _pos = item.intersection;
                _targetposBlasterValue = _pos - _saberPrefabs.transform.position;                
            }*/
            for(int i = 0; i < array.Length; i++)
            {
                var _pos = array[i].intersection;
                _targetposBlasterValue = _pos - _saberPrefabs.transform.position;               
            }

        }
        
    }   

    void SaberRotate()
    {
        float angle = Mathf.Atan2(_targetposBlasterValue.y, _targetposBlasterValue.x) * Mathf.Rad2Deg - 90;
        Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
        _saberPrefabs.transform.rotation = Quaternion.Slerp(_saberPrefabs.transform.rotation, angleAxis, 0.1f);
    }
    void FreeRotate()
    {
        transform.localRotation = Quaternion.Inverse(transform.parent.localRotation) * _LastParentRotation * transform.localRotation;
        _LastParentRotation = transform.parent.localRotation;
    }
    


}
