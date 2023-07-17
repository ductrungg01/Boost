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

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Obstacle":
                StartFailSequence();
                break;
            case "Destination":
                StartSuccessSequence();
                break;
            case "DeadZone":
                StartFailSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        GetComponent<RocketMoverment>().enabled = false;
        
        if (!successParticle.isPlaying)
            successParticle.Play();
        
        Debug.Log("Success");

        allowCollision = false;
        
        Invoke("LoadNextLevel", 3);
    }

    void StartFailSequence()
    {
        GetComponent<RocketMoverment>().enabled = false;
        
        if (!failParticle.isPlaying)
            failParticle.Play();
        
        Debug.Log("Fail");
        
        allowCollision = false;
        
        Invoke("ReloadLevel", 3);
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }

    void ReloadLevel()
    {
        levelManager.ReloadLevel();
    }
}
