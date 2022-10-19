using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXBlasterBehaviour_V1 : MonoBehaviour
{
    ParticleSystem _blasterParticle;
    ParticleSystem.Particle[] _arrayBlasterParticle;

    private void Start()
    {
        _blasterParticle = transform.GetChild(0).GetComponent<ParticleSystem>();
        Debug.Log(_blasterParticle.name);
    }

    private void LateUpdate()
    {
        int _numberBlasterParticleInArray = _blasterParticle.GetParticles(_arrayBlasterParticle);

        //if(bool true){
        //}

        _blasterParticle.SetParticles(_arrayBlasterParticle, _numberBlasterParticleInArray);
    }
}
