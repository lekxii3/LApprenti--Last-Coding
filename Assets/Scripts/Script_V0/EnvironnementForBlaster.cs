using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironnementForBlaster : MonoBehaviour
{
    FXBlasterBehaviour _blasterBehaviourScriptAccess;
    public bool collision;
    private LayerMask _environnementMask = 0<<6;
  
    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == _environnementMask)
        {
            collision = true;
            Debug.Log(other.name);
            //why not a event ? 
        }
    }
}
