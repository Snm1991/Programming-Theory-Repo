using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        if (transform.position.z < -25)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
