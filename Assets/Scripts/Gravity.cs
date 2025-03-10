using System;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    private const float G = 0.00674f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        
    }

    void Attract(Gravity other) 
    {
       Rigidbody rbOther = GetComponent<Rigidbody>();

       Vector3 direction = rb.position - rbOther.position;
       
       float distance = direction.magnitude;

       if (distance == 0) {return;}
       
       float forceMagnitude = G * ((rb.mass * rbOther.mass) / Mathf.Pow(distance, 2));
       Vector3 force = forceMagnitude * direction.normalized;
    }    
}
