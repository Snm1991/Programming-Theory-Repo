using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigo : MonoBehaviour
{
    [SerializeField] private int vel;
    public ParticleSystem explosionParticle;
    public GameObject focalPoint;
    public GameObject proyectilPrefab;
    [SerializeField] private float disparoRate;
    [SerializeField] private float startDelay;
    void Start()
    {
        InvokeRepeating("Disparar", startDelay, disparoRate);
    }
    void Disparar()
    {
        Instantiate(proyectilPrefab,
            new Vector3(focalPoint.transform.position.x, focalPoint.transform.position.y,
            focalPoint.transform.position.z),
            proyectilPrefab.transform.rotation);
    }
    void Update()
    {
            transform.Translate(0, 0, vel * Time.deltaTime);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MisilPlayer"))
        {
            explosionParticle.Play();
        }
    }
}
