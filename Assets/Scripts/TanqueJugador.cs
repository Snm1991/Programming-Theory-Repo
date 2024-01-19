using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TanqueJugador : Tanque
{
    [SerializeField] private GameObject focalPoint;
    private int escudoInicial = 100;
    private int escudoActual;
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private Slider balasSlider;
    private float disparo = 0.5f;
    private float disparoSiguiente = 1;
    [SerializeField] private Slider escudoSlider;
    private int balasInicial = 50;
    private int balasActual;
    [SerializeField] private ParticleSystem fireParticle;
    [SerializeField] private ParticleSystem golpeParticle;
    private int dañoRandom;
    private GameManager juegoActivo;
    private AudioSource sonidoDisparo;
    private AudioSource powerUpAudio;
    private AudioSource sonidoGolpe;
    [SerializeField] private GameObject rueda1;
    [SerializeField] private GameObject rueda2;
    [SerializeField] private GameObject rueda3;
    [SerializeField] private GameObject rueda4;
    void Start()
    {
        escudoActual = escudoInicial;
        balasActual = balasInicial;
        sonidoDisparo = GameObject.Find("Cañon").GetComponent<AudioSource>();
        powerUpAudio = GameObject.Find("Torreta").GetComponent<AudioSource>();
        dañoRandom = Random.Range(5, 15);
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
        sonidoGolpe = GameObject.Find("SonidoGolpes").GetComponent<AudioSource>();
    }
    void Update()
    {
        RotarRuedas(rueda1, rueda2, rueda3, rueda4);
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > disparoSiguiente && balasActual > 0
        && juegoActivo.juegoActivo)
        {
            Disparo();
        }
        if (escudoActual <= 0)
        {
            DestruirTanque();
            ExplosionTanque();
            juegoActivo.TerminarJuego();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MisilEnemy"))
        {
            Daño();
        }
    }
    protected override void Daño()
    {
        escudoActual -= dañoRandom;
        escudoSlider.value = escudoActual;
        sonidoGolpe.Play();
        golpeParticle.Play();
    }
    protected override void Disparo()
    {
        Instantiate(proyectilPrefab,
        new Vector3(focalPoint.transform.position.x, focalPoint.transform.position.y,
        focalPoint.transform.position.z),
        proyectilPrefab.transform.rotation);
        fireParticle.Play();
        sonidoDisparo.Play();
        disparoSiguiente = Time.time + disparo;
        balasActual -= 1;
        balasSlider.value = balasActual;
        if (balasActual <= 0)
        {
            balasActual = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CargadorBalas"))
        {
            CargarBalas();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("CargadorEscudo"))
        {
            CargarEscudo();
            Destroy(other.gameObject);
        }
    }
    void CargarBalas()
    {
        powerUpAudio.Play();
        balasActual += 25;
        balasSlider.value = balasActual;
        if (balasActual >= 50)
        {
            balasActual = 50;
        }
    }
    void CargarEscudo()
    {
        powerUpAudio.Play();
        escudoActual += 50;
        escudoSlider.value = escudoActual;
        if (escudoActual >= 100)
        {
            escudoActual = 100;
        }
    }
}
