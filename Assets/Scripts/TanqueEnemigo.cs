using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanqueEnemigo : Tanque
{
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject proyectilPrefab;
    private float disparoRandom;
    private bool destruir;
    private int vida;
    private GameManager juegoActivo;
    [SerializeField] private ParticleSystem fireParticle;
    private AudioSource sonidoDisparo;
    private int velocidadRandom;
    void Start()
    {
        disparoRandom = Random.Range(1.0f, 3.0f);
        InvokeRepeating("Disparar", 0.3f, disparoRandom);
        destruir = false;
        vida = Random.Range(5, 10);
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
        sonidoDisparo = GameObject.Find("Cañon").GetComponent<AudioSource>();
        velocidadRandom = Random.Range(1, 4);
    }
    void Update()
    {
        if (juegoActivo.juegoActivo)
        {
            MoverTanque();
        }
        if (!juegoActivo.juegoActivo)
        {
            DetenerMotor();
        }
        if (destruir)
        {
            Destroy(gameObject);
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
        if (vida == 0)
        {
            destruir = true;
        }
        ParticulaDaño();
    }
    protected void Disparar()
    {
        Instantiate(proyectilPrefab,
        new Vector3(focalPoint.transform.position.x, focalPoint.transform.position.y,
        focalPoint.transform.position.z),
        proyectilPrefab.transform.rotation);
        fireParticle.Play();
        sonidoDisparo.Play();
    }
    protected override void MoverTanque()
    {
        transform.Translate(0, 0, velocidadRandom * Time.deltaTime);
    }
}

