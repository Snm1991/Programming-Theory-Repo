using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanqueEnemigo : Tanque
{
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject proyectilPrefab;
    private float disparoRandom;
    private int vida;
    private GameManager juegoActivo;
    [SerializeField] private ParticleSystem fireParticle;
    private AudioSource sonidoDisparo;
    private int velocidadRandom;
    private AudioSource sonidoGolpe;
    [SerializeField] private ParticleSystem golpeParticle;
    [SerializeField] private GameObject rueda1;
    [SerializeField] private GameObject rueda2;
    [SerializeField] private GameObject rueda3;
    [SerializeField] private GameObject rueda4;
    void Start()
    {
        disparoRandom = Random.Range(1.5f, 3.5f);
        InvokeRepeating("Disparo", 0.3f, disparoRandom);
        vida = Random.Range(4, 9);
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
        sonidoDisparo = GameObject.Find("Cañon").GetComponent<AudioSource>();
        velocidadRandom = Random.Range(1, 4);
        sonidoGolpe = GameObject.Find("SonidoGolpes").GetComponent<AudioSource>();
    }
    void Update()
    {
        if (transform.position.z > 64)
        {
            DestruirTanque();
        }
        MoverTanque();
        RotarRuedas(rueda1, rueda2, rueda3, rueda4);
        if (vida == 0)
        {
            DestruirTanque();
            ExplosionTanque();
            juegoActivo.DescontarEnemigo();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MisilPlayer"))
        {
            Daño();
        }
    }
    protected override void Daño()
    {
        vida -= 1;
        sonidoGolpe.Play();
        golpeParticle.Play();
    }
    protected override void MoverTanque()
    {
        transform.Translate(0, 0, velocidadRandom * Time.deltaTime);
    }
    protected override void Disparo()
    {
        if (juegoActivo.juegoActivo)
        {
            Instantiate(proyectilPrefab,
            new Vector3(focalPoint.transform.position.x, focalPoint.transform.position.y,
            focalPoint.transform.position.z),
            proyectilPrefab.transform.rotation);
            fireParticle.Play();
            sonidoDisparo.Play();
        }
    }
}

