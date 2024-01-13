using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TanqueJugador : Tanque
{
    [SerializeField] private GameObject focalPoint;
    private int escudoInicial = 100;
    public int escudoActual;
    [SerializeField] private GameObject proyectilPrefab;
    [SerializeField] private Slider balasSlider;
    private float disparo = 0.5f;
    [SerializeField] private float disparoSiguiente;
    public Slider escudoSlider;
    private int balasInicial = 50;
    private int balasActual;
    [SerializeField] private ParticleSystem fireParticle;
    private int dañoRandom;
    private GameManager juegoActivo;
    private AudioSource sonidoDisparo;
    private AudioSource powerUpAudio;
    private AudioSource sonidoGolpe;
    void Start()
    {
        escudoActual = escudoInicial;
        balasActual = balasInicial;
        sonidoDisparo = GameObject.Find("Cañon").GetComponent<AudioSource>();
        powerUpAudio = GameObject.Find("Torreta").GetComponent<AudioSource>();
        dañoRandom = Random.Range(2, 5);
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
        sonidoGolpe = GameObject.Find("Player").GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > disparoSiguiente && balasActual > 0
        && juegoActivo.juegoActivo)
        {
            Disparar();
            CadenciaDisparo();
            DescontarBala();
        }
        if (escudoActual <= 0)
        {
            Destroy(gameObject);
            ExplosionTanque();
            juegoActivo.TerminarJuego();
        }
        if (!juegoActivo.juegoActivo)
        {
            DetenerMotor();
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
    void CadenciaDisparo()
    {
        disparoSiguiente = Time.time + disparo;
    }
    void DescontarBala()
    {
        balasActual -= 1;
        balasSlider.value = balasActual;
        if (balasActual <= 0)
        {
            balasActual = 0;
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
}
