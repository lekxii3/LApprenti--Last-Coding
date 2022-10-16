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

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Protection"))
        {

        }
    }
}
