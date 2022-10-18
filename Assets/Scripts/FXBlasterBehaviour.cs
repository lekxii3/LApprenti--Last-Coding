using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXBlasterBehaviour : MonoBehaviour
{
    ParticleSystem _particlBlaster;
    void Start()
    {
        _particlBlaster = GetComponent<ParticleSystem>();
        _particlBlaster.Play();
    }

    //for each instantiate ennemy, event signal to saber for add List. For avoid
    // use update 
}
