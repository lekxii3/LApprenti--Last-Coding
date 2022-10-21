using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager_V1 : MonoBehaviour
{
    public Collider _saber;
    List<EnvironnementBehaviour_V1> _environnementList = new List<EnvironnementBehaviour_V1>();
    LayerMask _environnementLayerMask = 6;
    
    //Script too heavy, must update
    void Start()
    {
       foreach(EnvironnementBehaviour_V1 scriptEnv in Resources.FindObjectsOfTypeAll(typeof(EnvironnementBehaviour_V1)))
        {
            if(scriptEnv.gameObject.layer == _environnementLayerMask)
            {
                _environnementList.Add(scriptEnv);               

                for( int i = 0; i < _environnementList.Count; i++)
                {
                    if( _environnementList[i].GetComponent<Collider>() != null)
                    {
                        Debug.Log(_environnementList[i].name);
                        Physics.IgnoreCollision(_environnementList[i].GetComponent<Collider>(), _saber);
                    }
                }
            }
        }
       
    }
    
}
