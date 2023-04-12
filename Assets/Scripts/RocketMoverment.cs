using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RocketMoverment : MonoBehaviour
{
    private Rigidbody rb;
    private Transform transform;

    [SerializeField] private float thrustFactor = 1000f;
    [SerializeField] private float maxThrust = 5f;
    [SerializeField] private float rotateFactor = 100f;

    [SerializeField] private ParticleSystem mainBoostParticle;
    [SerializeField] private ParticleSystem rightBoostParticle;
    [SerializeField] private ParticleSystem leftBoostParticle;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.magnitude < maxThrust)
            {
                if (!mainBoostParticle.isPlaying)
                {
                    mainBoostParticle.Play();
                }
                rb.AddRelativeForce(Vector3.up * (thrustFactor * Time.deltaTime));
            }
        }
        else
        {
            mainBoostParticle.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!rightBoostParticle.isPlaying)
            {
                rightBoostParticle.Play();
            }
            ApplyRotate(rotateFactor);
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!leftBoostParticle.isPlaying)
            {
                leftBoostParticle.Play();
            }
            ApplyRotate(-rotateFactor);
        }
        else
        {
            leftBoostParticle.Stop();
            rightBoostParticle.Stop();
        }
    }

    void ApplyRotate(float rotateThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(rotateThisFrame * Time.deltaTime * Vector3.forward);
        rb.freezeRotation = false;
    }

}
