using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXBlasterBehaviour_V1 : MonoBehaviour
{
    ParticleSystem _blasterParticle;
    ParticleSystem.Particle[] _arrayBlasterParticle;
    public List<Vector3> _positionBlaster=new List<Vector3>();
    
    private void Start()
    {
        _blasterParticle = transform.GetChild(0).GetComponent<ParticleSystem>();          
    }

    private void OnEnable()
    {
        EnvironnementBehaviour_V1.CollisionBlasterEnvironementSignal += DestroyBlaster;
        SaberBehaviour_V1.CollisionBlasterSaberSignal += PositionCollisionBlaster;
        
    }
    private void OnDisable()
    {
        EnvironnementBehaviour_V1.CollisionBlasterEnvironementSignal -= DestroyBlaster;
        SaberBehaviour_V1.CollisionBlasterSaberSignal -= PositionCollisionBlaster;
    }
   

    private void LateUpdate()
    {
        ReinitializeIfNeeded();        
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
    void PositionCollisionBlaster()
    {
        int _numberBlasterParticleInArray = _blasterParticle.GetParticles(_arrayBlasterParticle);

        for (int i = 0; i < _arrayBlasterParticle.Length; i++)
        {
            _positionBlaster.Add(_arrayBlasterParticle[i].position);
        }

        _blasterParticle.SetParticles(_arrayBlasterParticle, _numberBlasterParticleInArray);

        Debug.Log(_positionBlaster.Count);
        Debug.Log(_positionBlaster[0]);
        Debug.Log(_positionBlaster[1]);
        Debug.Log(_positionBlaster[2]);
        Debug.Log(_positionBlaster[3]);
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
