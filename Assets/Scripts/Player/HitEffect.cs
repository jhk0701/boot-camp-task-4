using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField] private float burstAmount = 10f;
    [SerializeField] ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    public void Act(Vector3 hitPoint, Vector3 direction)
    {
        transform.position = hitPoint;
        transform.rotation = Quaternion.LookRotation(direction);
        
        ParticleSystem.EmissionModule em = particle.emission;
        em.SetBurst(0, new ParticleSystem.Burst(0, burstAmount));
        particle.Play();
    }
}
