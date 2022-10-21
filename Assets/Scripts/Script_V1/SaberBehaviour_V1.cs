using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SaberBehaviour_V1 : MonoBehaviour
{
    LayerMask _BlasterLayerMask = 8;
    private ParticleCollisionEvent[] _collisionPos;
    [SerializeField] GameObject _saberPrefabs;
    float _positionX;
    float _positionY;
    float _positionZ;
    
    float _rotationX;
    float _rotationY;

    private void Update()
    {
        Time.timeScale = 1f;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == _BlasterLayerMask)
        {
            var array = new ParticleCollisionEvent[other.GetComponent<ParticleSystem>().GetSafeCollisionEventSize()];
            int count = other.GetComponent<ParticleSystem>().GetCollisionEvents(gameObject, array);
            foreach(ParticleCollisionEvent item in array)
            {
                var _pos = item.intersection;
                Vector3 _targetpos = _pos - _saberPrefabs.transform.position;
                float angle = Mathf.Atan2(_targetpos.y, _targetpos.x)*Mathf.Rad2Deg-90; 

                Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);

                _saberPrefabs.transform.rotation = Quaternion.Slerp(_saberPrefabs.transform.rotation, angleAxis, 0.1f); 
            }
            
        }
    }
   
}
