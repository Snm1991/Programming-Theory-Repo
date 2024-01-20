using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TanqueJugador : Tanque //HERENCIA
{
    //VARIABLES GAME OBJECTS
    [SerializeField] private GameObject rueda1;
    [SerializeField] private GameObject rueda2;
    [SerializeField] private GameObject rueda3;
    [SerializeField] private GameObject rueda4;
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject proyectilPrefab;
    //VARIABLES INT
    private int escudoInicial = 100;
    private int escudoActual;
    private int balasInicial = 50;
    private int balasActual;
    private int dañoRandom;
    //VARIABLES FLOAT
    private float disparo = 0.5f;
    private float disparoSiguiente = 1;
    //VARIABLES TIPO SLIDER
    [SerializeField] private Slider escudoSlider;
    [SerializeField] private Slider balasSlider;
    //VARIABLES SISTEMA DE PARTICULAS
    [SerializeField] private ParticleSystem fireParticle;
    [SerializeField] private ParticleSystem golpeParticle;
    //VARIABLE DE SCRIPT
    private GameManager juegoActivo;
    private AudioSource sonidoDisparo;
    //AUDIO
    private AudioSource powerUpAudio;
    private AudioSource sonidoGolpe;

    void Start()
    {
        //SE IGUALAN LAS VARIABLES INICIALES CON LAS ACTUALES AL COMIENZO DEL JUEGO
        escudoActual = escudoInicial;
        balasActual = balasInicial;
        //SE TRAEN COMPONENTES DE GAMEOBJECTS
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
        sonidoGolpe = GameObject.Find("SonidoGolpes").GetComponent<AudioSource>();
        sonidoDisparo = GameObject.Find("Cañon").GetComponent<AudioSource>();
        powerUpAudio = GameObject.Find("Torreta").GetComponent<AudioSource>();
        //EL TANQUE RECIBE UN DAÑO ALEATORIO
        dañoRandom = Random.Range(5, 15);
        
    }
    void Update()
    {
        //SE ROTAN LAS RUEDAS
        RotarRuedas(rueda1, rueda2, rueda3, rueda4);
        //DISPARAR CON BARRA ESPACIADORA
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > disparoSiguiente && balasActual > 0
        && juegoActivo.juegoActivo)
        {
            Disparo();
        }
        //DESTRUIR AL QUEDARSE SIN VIDA
        if (escudoActual <= 0)
        {
            DestruirTanque();
            ExplosionTanque();
            juegoActivo.TerminarJuego();
        }
    }
    //RECIBIR DAÑO AL COLISIONAR CON MISIL ENEMIGO
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MisilEnemy"))
        {
            Daño();
        }
    }
    //RECIBE DAÑO, SOBREESCRIBE EL METODO POLIMORFISMO
    protected override void Daño()
    {
        escudoActual -= dañoRandom;
        escudoSlider.value = escudoActual;
        sonidoGolpe.Play();
        golpeParticle.Play();
    }
    //DISPARA, SOBREESCRIBE EL METODO POLIMORFISMO
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
    //SE CARGAN BALAS Y VIDA AL COLISIONAR CON POWER UP
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
