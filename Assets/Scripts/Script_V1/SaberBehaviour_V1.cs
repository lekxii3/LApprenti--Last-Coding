using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        _rotationX = Mathf.Clamp(_rotationX, 0, 0);
        _rotationY = Mathf.Clamp(_rotationY, 0, 0);
        _saberPrefabs.transform.eulerAngles = new Vector3(_rotationX, _rotationY, 0);
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

            }
        }
    }
   
}
