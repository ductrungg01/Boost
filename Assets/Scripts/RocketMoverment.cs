using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMoverment : MonoBehaviour
{
    private Rigidbody rb;
    private Transform transform;

    [SerializeField] private float thrustFactor = 1000f;
    [SerializeField] private float maxThrust = 5f;
    [SerializeField] private float rotateFactor = 100f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        Debug.Log(rb.velocity.magnitude);
        
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.magnitude < maxThrust)
            {
                rb.AddRelativeForce(Vector3.up * (thrustFactor * Time.deltaTime));
            }
        }
    }

    void ProcessRotation()
    {
        Vector3 rotateForce = rotateFactor * Time.deltaTime * Vector3.forward;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotate(rotateForce);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotate(-rotateForce);
        }
    }

    void ApplyRotate(Vector3 rotateForce)
    {
        rb.freezeRotation = true;
        transform.Rotate(rotateForce);
        rb.freezeRotation = false;
    }
}
