using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class SaberBehaviour_V1 : MonoBehaviour
{
    public testXRsimple testXRsimpleScriptAccess;
    LayerMask _BlasterLayerMask = 8;
    private ParticleCollisionEvent[] _collisionPos;
    [SerializeField] GameObject _saberPrefabsDefense;
    Vector3 _targetposBlasterValue;
    public bool _contactBlaster;
    [SerializeField] bool _endArray;
    public Transform _empty;
    

    private void Update()
    {
        
            SaberRotate();

            
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == _BlasterLayerMask)
        {
            _contactBlaster = true;
            //_saberPrefabsDefense.SetActive(true);
            var array = new ParticleCollisionEvent[other.GetComponent<ParticleSystem>().GetSafeCollisionEventSize()];
            int count = other.GetComponent<ParticleSystem>().GetCollisionEvents(gameObject, array);
            
            for(int i = 0; i < array.Length; i++)
            {
                var _pos = array[i].intersection;

                //_empty.transform.position = array[i].intersection;
                //_empty.transform.rotation = transform.rotation;

                _targetposBlasterValue = _pos -  transform.position;

                if (i <= array.Length)
                {
                    _endArray = true;
                }
            }
        }        
    }   

    void SaberRotate()
    {
        var angle = Mathf.Atan2(_targetposBlasterValue.y,_targetposBlasterValue.x)* Mathf.Rad2Deg-90;
        Quaternion rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);
        _saberPrefabsDefense.transform.rotation = Quaternion.Slerp(_saberPrefabsDefense.transform.rotation, rotation, 0.1f);        

    }




    IEnumerator Delay()
    {        
        yield return new WaitForSeconds(1f);
        float _angleDeRetour = Mathf.Atan2(0,0)*Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(_angleDeRetour, _empty.forward);
        _saberPrefabsDefense.transform.rotation = Quaternion.Slerp(_saberPrefabsDefense.transform.rotation, angleAxis, 0.1f);
        _contactBlaster = false;
        _endArray = false;
        //_saberPrefabsDefense.SetActive(false);
    }



































    /*Debug.DrawLine(array[i].intersection, array[i].intersection + Vector3.right / 2, Color.red, 0.5f);
                Debug.DrawLine(array[i].intersection, array[i].intersection + Vector3.up / 2, Color.green, 0.5f);
                Debug.DrawLine(array[i].intersection, array[i].intersection + Vector3.forward / 2, Color.blue, 0.5f);*/

    /*float angleX = Vector3.SignedAngle(array[i].intersection, transform.position,Vector3.right)*Mathf.Deg2Rad;
    Debug.Log("angleX "+angleX);
    float angleY = Vector3.SignedAngle(array[i].intersection , transform.position, Vector3.up) * Mathf.Deg2Rad;
    Debug.Log("angleY "+angleY);
    float angleZ = Vector3.SignedAngle(array[i].intersection, transform.position, Vector3.forward) * Mathf.Deg2Rad;
    Debug.Log("angleZ "+angleZ);

    Debug.DrawLine(array[i].intersection, Vector3.RotateTowards(array[i].intersection, array[i].intersection, angleX, angleX) +Vector3.right, Color.red, 0.5f);
    Debug.DrawLine(array[i].intersection, Vector3.RotateTowards(array[i].intersection, array[i].intersection, angleY, angleY) +Vector3.up, Color.green, 0.5f);
    Debug.DrawLine(array[i].intersection, Vector3.RotateTowards(array[i].intersection, array[i].intersection, angleZ, angleZ) +Vector3.forward, Color.blue, 0.5f);*/
}
