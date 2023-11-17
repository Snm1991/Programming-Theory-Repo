using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.AddForce(transform.forward, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
