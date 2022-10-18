using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXBlasterBehaviour : MonoBehaviour
{
    ParticleSystem _particlBlaster;
    public ParticleSystem _particlBlaster1;
    public ParticleSystem.Particle[] m_blaster;    
    void Start()
    {
        _particlBlaster = GetComponent<ParticleSystem>();
        _particlBlaster1 = transform.GetChild(0).GetComponent<ParticleSystem>();
        Debug.Log(_particlBlaster1.name);
        _particlBlaster.Play();
    }

    //for each instantiate ennemy, event signal to saber for add List. For avoid
    // use update 


    private void Update()
    {
       
    }
















    /*private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward));
        RaycastHit _hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _hit, Mathf.Infinity))
        {
            if (_hit.collider.CompareTag("Player"))
            {
                Debug.Log("damage");

            }
            if (_hit.collider.CompareTag("Protection"))
            {
                Debug.Log("Blaster deviated");
                var GetScript = _particlBlaster1.collision;
                               
                 GetScript.bounce = 1;
                 GetScript.dampen = 0;
                 GetScript.lifetimeLoss = 0.5f;
            }
            else
            {
                var GetScript = _particlBlaster1.collision;

                GetScript.bounce = 0;
                GetScript.dampen = 1;
                GetScript.lifetimeLoss = 1;
            }
        }
    }*/
}
