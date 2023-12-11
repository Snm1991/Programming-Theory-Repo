using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    private GameManager juegoActivo;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
        if (transform.position.z < -25 || !juegoActivo.juegoActivo)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
