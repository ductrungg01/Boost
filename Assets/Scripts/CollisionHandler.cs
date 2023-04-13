using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    
    [SerializeField] private ParticleSystem successParticle;
    [SerializeField] private ParticleSystem failParticle;

    [HideInInspector] public bool allowCollision = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (levelManager.isTransition || allowCollision == false)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Friendly"))
        {
            // do nothing
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Fail();
        } else if (collision.gameObject.CompareTag("Destination"))
        {
            Success();
        } else if (collision.gameObject.CompareTag("DeadZone"))
        {
            Fail();
        }
    }

    void Fail()
    {
        if (!failParticle.isPlaying)
            failParticle.Play();
    }

    void Success()
    {
        if (!successParticle.isPlaying)
            successParticle.Play();
    }
}
