using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberBehaviour_V1 : MonoBehaviour
{
    LayerMask _BlasterLayerMask = 8;
    public delegate void CollisionBlasterSaber();
    public static CollisionBlasterSaber CollisionBlasterSaberSignal;

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == _BlasterLayerMask)
        {
            CollisionBlasterSaberSignal?.Invoke();           
        }
    }
}
