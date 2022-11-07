using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironnementBehaviour_V1 : MonoBehaviour
{
    LayerMask _BlasterLayerMask = 8;
    public static event Action CollisionBlasterEnvironementSignal;

    private void OnParticleCollision(GameObject other)
    {
        if(other.layer == _BlasterLayerMask)
        {    
            CollisionBlasterEnvironementSignal?.Invoke(); //Signal to FXBlasterBehaviour
        }
    }
}
