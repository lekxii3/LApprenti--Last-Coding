using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SaberBehaviour_V1 : MonoBehaviour
{
    public SaberArmed_V1 SaberArmed_V1AccessScript;
    public GrabSaber_V1 GrabSaber_V1ScriptAccess;
    LayerMask _BlasterLayerMask = 8;
    private ParticleCollisionEvent[] _collisionPos;
    [SerializeField] GameObject _saberPrefabsDefense;
    Vector3 _targetposBlasterValue;
    public bool _usingSaber;
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
        if(GrabSaber_V1ScriptAccess.isUsing == true && SaberArmed_V1AccessScript.armedBool==true)
        {
            _usingSaber = true;

            if (_protectionActived)
            {
                SaberRotate();
                _timer += Time.deltaTime;
            }
            else
            {
                SaberReturnPose();
                _timer = 0;
            }
        }        
    }

    private void OnParticleCollision(GameObject other)
    {
        
        if (other.layer == _BlasterLayerMask)
        {
            _timer = 0;
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

        if (_contactBlaster && _timer < 0.15f) 
        {
            var angle = Mathf.Atan2(_targetposBlasterValue.y, _targetposBlasterValue.x) * Mathf.Rad2Deg - 90;                           //calculate with X and Y for get angle but convert Radian to Degree with -90°
            Quaternion rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angle);          //Euler methode for rotate toward here target 
            _saberPrefabsDefense.transform.rotation = Quaternion.Slerp(_saberPrefabsDefense.transform.rotation, rotation, 0.3f);        //Slerp for interpolate rotation
                      
        }
        else if(_contactBlaster && _timer > 0.15f)
        {
            _saberPrefabsDefense.transform.rotation = Quaternion.Slerp(_saberPrefabsDefense.transform.rotation, GrabSaber_V1ScriptAccess.transform.rotation, 0.1f);
        }
    }
    
    void SaberReturnPose()
    {
        _colliderProtection.enabled = false;
        _saberPrefabsDefense.transform.rotation = Quaternion.Slerp(_saberPrefabsDefense.transform.rotation, GrabSaber_V1ScriptAccess.transform.rotation, 0.5f);
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
