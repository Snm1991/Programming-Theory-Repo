using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovJugador : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public GameObject focalPoint;
    public ParticleSystem fireParticle;
    public ParticleSystem explosionParticles;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(proyectilPrefab,
            new Vector3(focalPoint.transform.position.x, focalPoint.transform.position.y,
            focalPoint.transform.position.z),
            proyectilPrefab.transform.rotation);
            fireParticle.Play();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MisilEnemy"))
        {
            explosionParticles.Play();
        }
    }
}
