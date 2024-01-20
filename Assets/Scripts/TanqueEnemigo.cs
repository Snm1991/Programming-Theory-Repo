using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanqueEnemigo : Tanque //HERENCIA
{
    //VARIABLES GAMEOBJECT
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private GameObject rueda1;
    [SerializeField] private GameObject rueda2;
    [SerializeField] private GameObject rueda3;
    [SerializeField] private GameObject rueda4;
    //VARIABLES INT Y FLOAT
    private int velocidadRandom;
    private int vida;
    private float disparoRandom;
    //VARIABLE DE SCRIPT
    private GameManager juegoActivo;
    //SISTEMA DE PARTICULAS
    [SerializeField] private ParticleSystem fireParticle;
    [SerializeField] private ParticleSystem golpeParticle;
    //AUDIO
    private AudioSource sonidoDisparo;
    private AudioSource sonidoGolpe;


    void Start()
    {
        //SE DISPARA DE FORMA ALEATORIA
        disparoRandom = Random.Range(1.5f, 3.5f);
        InvokeRepeating("Disparo", 0.3f, disparoRandom);
        //VIDA ALEATORIA
        vida = Random.Range(4, 9);
        //VELOCIDAD ALEATORIA
        velocidadRandom = Random.Range(1, 4);
        //SE TRAEN COMPONENTES DE GAMEOBJECTS
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
        sonidoDisparo = GameObject.Find("Cañon").GetComponent<AudioSource>();
        sonidoGolpe = GameObject.Find("SonidoGolpes").GetComponent<AudioSource>();
    }
    void Update()
    {
        //SI EL ENEMIGO SALE DE LOS LIMITES, SE DESTRUYE
        if (transform.position.z > 64)
        {
            DestruirTanque();
        }
        //MOVER TANQUE ROTANDO SUS RUEDAS
        MoverTanque();
        RotarRuedas(rueda1, rueda2, rueda3, rueda4);
        //DESTRUIR ENEMIGO SI NO LE QUEDA VIDA
        if (vida == 0)
        {
            DestruirTanque();
            ExplosionTanque();
            juegoActivo.DescontarEnemigo();
        }
    }
    //SI COLISIONA CON EL MISIL DEL JUGADOR, RECIBE DAÑO
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MisilPlayer"))
        {
            Daño();
        }
    }
    //RECIBIR DAÑO, SOBREESCRIBE EL METODO POLIMORFISMO
    protected override void Daño()
    {
        vida -= 1;
        sonidoGolpe.Play();
        golpeParticle.Play();
    }
    //MOVER TANQUE, SOBREESCRIBE EL METODO POLIMORFISMO
    protected override void MoverTanque()
    {
        transform.Translate(0, 0, velocidadRandom * Time.deltaTime);
    }
    //DISPARAR, SOBREESCRIBE EL METODO POLIMORFISMO
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

