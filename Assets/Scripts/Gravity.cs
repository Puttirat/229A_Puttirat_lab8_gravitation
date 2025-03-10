using System;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody rb;
    private const float G = 0.00674f;

    public static List<Gravity> gravityObjectsList ;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (gravityObjectsList == null)
        {
            gravityObjectsList = new List<Gravity>();
        }
        
        gravityObjectsList.Add(this);
    }
    private void FixedUpdate()
    {
        foreach (Gravity obj in gravityObjectsList)
        {
            Attract(obj);
        }
    }

    void Attract(Gravity other) 
    {
       Rigidbody rbOther = other.rb ;

       Vector3 direction = rb.position - rbOther.position;
       
       float distance = direction.magnitude;

       if (distance == 0) {return;}
       
       float forceMagnitude = G * ((rb.mass * rbOther.mass) / Mathf.Pow(distance, 2));
       Vector3 force = forceMagnitude * direction.normalized;
       rbOther.AddForce(force);
    }    
}
