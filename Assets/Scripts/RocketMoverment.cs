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
            StartThrust();
        }
        else
        {
            StopThrust();
        }
    }

    private void StopThrust()
    {
        mainBoostParticle.Stop();
    }

    private void StartThrust()
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

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateLeft();
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateRight();
        }
        else
        {
            StopRotate();
        }
    }

    private void RotateLeft()
    {
        if (!rightBoostParticle.isPlaying)
        {
            rightBoostParticle.Play();
        }

        ApplyRotate(rotateFactor);
    }

    private void RotateRight()
    {
        if (!leftBoostParticle.isPlaying)
        {
            leftBoostParticle.Play();
        }

        ApplyRotate(-rotateFactor);
    }

    private void StopRotate()
    {
        leftBoostParticle.Stop();
        rightBoostParticle.Stop();
    }

    void ApplyRotate(float rotateThisFrame)
    {
        transform.Rotate(rotateThisFrame * Time.deltaTime * Vector3.forward);
    }

}
