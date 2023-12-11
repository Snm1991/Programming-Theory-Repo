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
    private GameManager juegoActivo;
    private SpawnManager cantEnemigos;
    public AudioSource explosionAudio;
    public AudioSource motorAudio;
    public AudioSource contadorAudio;
    void Start()
    {
        InvokeRepeating("Disparar", startDelay, disparoRate);
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
        cantEnemigos = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        explosionAudio = GameObject.Find("ExplosionPorGolpe").GetComponent<AudioSource>();
        motorAudio = GetComponent<AudioSource>();
        contadorAudio = GameObject.Find("Contador").GetComponent<AudioSource>();
    }
    void Disparar()
    {
        if (juegoActivo.juegoActivo)
        {
            Instantiate(proyectilPrefab,
                new Vector3(focalPoint.transform.position.x, focalPoint.transform.position.y,
                focalPoint.transform.position.z),
                proyectilPrefab.transform.rotation);
            fireParticle.Play();
            explosionAudio.Play();
        }
    }
    void Update()
    {
        if (juegoActivo.juegoActivo)
        {
            transform.Translate(0, 0, vel * Time.deltaTime);
        }
        if (!juegoActivo.juegoActivo)
        {
            motorAudio.Stop();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MisilPlayer"))
        {
            explosionParticle.Play();
            explosionAudio.Play();
            vida -= 1;
        }
        if (vida == 0)
        {
            Destroy(gameObject);
            Instantiate(destruccionParticle, transform.position,
            destruccionParticle.transform.rotation);
            cantEnemigos.cantEnemigos -= 1;
            contadorAudio.Play();
        }
    }
}
