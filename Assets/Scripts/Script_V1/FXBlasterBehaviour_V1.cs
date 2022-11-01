using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXBlasterBehaviour_V1 : MonoBehaviour
{
    ParticleSystem _blasterParticle;
    ParticleSystem.Particle[] _arrayBlasterParticle;
    public Transform Player;
    
    private void Start()
    {
        _blasterParticle = transform.GetChild(0).GetComponent<ParticleSystem>();          
    }
  

    private void OnEnable()
    {
        EnvironnementBehaviour_V1.CollisionBlasterEnvironementSignal += DestroyBlaster;
        
    }
    private void OnDisable()
    {
        EnvironnementBehaviour_V1.CollisionBlasterEnvironementSignal -= DestroyBlaster;
    }
   

    private void FixedUpdate()
    {
        ReinitializeIfNeeded();
        transform.LookAt(Player);
    }

    void DestroyBlaster()
    {        
        int _numberBlasterParticleInArray = _blasterParticle.GetParticles(_arrayBlasterParticle);

        for(int i = 0; i < _arrayBlasterParticle.Length; i++)
        {
            _arrayBlasterParticle[i].remainingLifetime = 0;
        }

        _blasterParticle.SetParticles(_arrayBlasterParticle, _numberBlasterParticleInArray);
    }
    
    void ReinitializeIfNeeded()
    {
        if (_blasterParticle == null)
        {
            _blasterParticle= transform.GetChild(0).GetComponent<ParticleSystem>();
        }
        if(_arrayBlasterParticle == null || _arrayBlasterParticle.Length < _blasterParticle.main.maxParticles)
        {
            _arrayBlasterParticle = new ParticleSystem.Particle[_blasterParticle.main.maxParticles];
        }
    }
    
}
