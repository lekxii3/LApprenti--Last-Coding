using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXBlasterBehaviour : MonoBehaviour
{
    ParticleSystem _particlBlaster;
    public ParticleSystem _particlBlaster1;
    public ParticleSystem.Particle[] m_blaster;
    private EnvironnementForBlaster _environnementForBlasterAccessScript;
    void Start()
    {
        _particlBlaster = GetComponent<ParticleSystem>();
        _particlBlaster1 = transform.GetChild(0).GetComponent<ParticleSystem>();
        _particlBlaster.Play();
        _environnementForBlasterAccessScript = FindObjectOfType<EnvironnementForBlaster>();
    }

    //for each instantiate ennemy, event signal to saber for add List. For avoid
    // use update 


    private void LateUpdate()
    {
        InitializeIfNeeded();
        int _numBlasterDeviated = _particlBlaster1.GetParticles(m_blaster);
        if (_environnementForBlasterAccessScript.collision == true)  
        {
            float _drift = 1f;
            for (int i = 0; i < _numBlasterDeviated; i++)
            {
                m_blaster[i].remainingLifetime = -1;
            }
            _particlBlaster1.SetParticles(m_blaster, _numBlasterDeviated);
            _environnementForBlasterAccessScript.collision = false;
        }




        void InitializeIfNeeded()
        {
            if (_particlBlaster1 == null)
            {
                _particlBlaster1=GetComponent<ParticleSystem>();
            }
            if(_particlBlaster1 == null || m_blaster.Length < _particlBlaster1.main.maxParticles)
            {
                m_blaster = new ParticleSystem.Particle[_particlBlaster1.main.maxParticles];
            }
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
}
