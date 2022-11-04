using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SaberBehaviour_V1 : MonoBehaviour
{
    public GrabSaber_V1 GrabSaber_V1ScriptAccess;
    LayerMask _BlasterLayerMask = 8;
    private ParticleCollisionEvent[] _collisionPos;
    [SerializeField] GameObject _saberPrefabsDefense;
    Vector3 _targetposBlasterValue;
    public bool _contactBlaster;
    private bool _protectionActived;
    private Collider _colliderProtection;
    private float _timer;

    private void Start()
    {
        _colliderProtection = GetComponent<Collider>();
    }


    private void OnEnable()
    {
        HandRightBehaviour_V1.PrimaryButtonProtectionActivate += ActivateProtection;
        HandRightBehaviour_V1.PrimaryButtonProtectionDeactivate += DeactivateProtection;
    }

    private void OnDisable()
    {
        HandRightBehaviour_V1.PrimaryButtonProtectionActivate -= ActivateProtection;
        HandRightBehaviour_V1.PrimaryButtonProtectionDeactivate -= DeactivateProtection;
    }

    private void Update()
    {
        if (_protectionActived)
        {
            SaberRotate();            
        }
        else
        {
            SaberReturnPose();
        }
        TimerForReturnPoseDuringDefenseIfNoBlasterCollision();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == _BlasterLayerMask)
        {
            _contactBlaster = true;
            var array = new ParticleCollisionEvent[other.GetComponent<ParticleSystem>().GetSafeCollisionEventSize()];       //create variable for create a new array for information case each event particle contact 
            int count = other.GetComponent<ParticleSystem>().GetCollisionEvents(gameObject, array);                         //same index 
            
            for(int i = 0; i < array.Length; i++)
            {
                var _pos = array[i].intersection;

                _targetposBlasterValue = _pos -  transform.position;                
            }
        }        
    }   

    void ActivateProtection()
    {
        Debug.Log("Protection Activated");
        _protectionActived = true;
    }

    void DeactivateProtection()
    {
        Debug.Log("Protection Deactivated");
        _protectionActived = false;
    }

    void SaberRotate()
    {
        _colliderProtection.enabled = true;
        var angle = Mathf.Atan2(_targetposBlasterValue.y,_targetposBlasterValue.x)* Mathf.Rad2Deg-90;                               //calculate with X and Y for get angle but convert Radian to Degree with -90°
        Quaternion rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);          //Euler methode for rotate toward here target 
        _saberPrefabsDefense.transform.rotation = Quaternion.Slerp(_saberPrefabsDefense.transform.rotation, rotation, 0.1f);        //Slerp for interpolate rotation
    }

    void TimerForReturnPoseDuringDefenseIfNoBlasterCollision()
    {
        if (_contactBlaster)
        {
            _timer = _timer+Time.deltaTime;
            if (_timer >= 2)
            {                
                _saberPrefabsDefense.transform.rotation = Quaternion.Slerp(_saberPrefabsDefense.transform.rotation, GrabSaber_V1ScriptAccess.transform.rotation,0.8f);
                _timer = 0; 
                _contactBlaster = false;
            }
            
        }
    }

    void SaberReturnPose()
    {
        _colliderProtection.enabled = false;
        _saberPrefabsDefense.transform.rotation = Quaternion.Slerp(_saberPrefabsDefense.transform.rotation, GrabSaber_V1ScriptAccess.transform.rotation, 0.5f);
    }

    IEnumerator Delay()
    {        
        yield return new WaitForSeconds(1f);
        float _angleDeRetour = Mathf.Atan2(0,0)*Mathf.Rad2Deg;
        //Quaternion angleAxis = Quaternion.AngleAxis(_angleDeRetour, _empty.forward);
        //_saberPrefabsDefense.transform.rotation = Quaternion.Slerp(_saberPrefabsDefense.transform.rotation, angleAxis, 0.1f);
        _contactBlaster = false;       
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
