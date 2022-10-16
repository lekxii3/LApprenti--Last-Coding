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
        Debug.Log(other.name);

        if (other.CompareTag("Protection"))
        {
            Debug.Log("touche");
            var _modifier = _particlBlaster.collision;
            _modifier.dampen = 0f;
            _modifier.bounce = 1f;
        }
    }
}
