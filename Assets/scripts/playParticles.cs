using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playParticles : MonoBehaviour
{
    public ParticleSystem hitCyclist;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hitCyclist.Play();
        }
        
    }
}
