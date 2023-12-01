using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigo : MonoBehaviour
{
    [SerializeField] private int vel;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem destruccionParticle;
    [SerializeField] private ParticleSystem fireParticle;
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private float disparoRate;
    [SerializeField] private float startDelay;
    [SerializeField] private int vida;
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
        fireParticle.Play();
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
            vida -= 1;
        }
        if (vida == 0)
        {
            Destroy(gameObject);
            Instantiate(destruccionParticle, transform.position,
            destruccionParticle.transform.rotation);
        }
    }
}
