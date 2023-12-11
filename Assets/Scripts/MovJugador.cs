using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovJugador : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public GameObject focalPoint;
    public ParticleSystem fireParticle;
    public ParticleSystem explosionParticles;
    [SerializeField] public ParticleSystem destruccionParticle;
    [SerializeField] private float disparoSiguiente;
    private float disparo = 0.5f;
    private int escudoInicial = 100;
    private int escudoActual;
    private int dañoEnemigo = 10;
    [SerializeField] private Slider escudoSlider;
    private int balasInicial = 50;
    private int balasActual;
    [SerializeField] private Slider balasSlider;
    [SerializeField] private GameObject canvasPerder;
    private GameManager juegoActivo;
    public AudioSource explosionAudio;
    public AudioSource powerUpAudio;
    public AudioSource motorAudio;
    void Start()
    {
        escudoActual = escudoInicial;
        balasActual = balasInicial;
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
        explosionAudio = GameObject.Find("ExplosionCañon").GetComponent<AudioSource>();
        powerUpAudio = GameObject.Find("Cañon").GetComponent<AudioSource>();
        motorAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > disparoSiguiente && balasActual > 0
        && juegoActivo.juegoActivo)
        {
            Instantiate(proyectilPrefab,
            new Vector3(focalPoint.transform.position.x, focalPoint.transform.position.y,
            focalPoint.transform.position.z),
            proyectilPrefab.transform.rotation);
            disparoSiguiente = Time.time + disparo;
            fireParticle.Play();
            explosionAudio.Play();
            balasActual -= 1;
            balasSlider.value = balasActual;
            if (balasActual <= 0)
            {
                balasActual = 0;
            }
        }
        if (!juegoActivo.juegoActivo)
        {
            motorAudio.Stop();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MisilEnemy"))
        {
            escudoActual -= dañoEnemigo;
            escudoSlider.value = escudoActual;
            explosionParticles.Play();
            explosionAudio.Play();
            if (escudoActual <= 0)
            {
                escudoActual = 0;
                Destroy(gameObject);
                Instantiate(destruccionParticle, transform.position,
                destruccionParticle.transform.rotation);
                canvasPerder.SetActive(true);
                juegoActivo.juegoActivo = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CargarBalas"))
        {
            powerUpAudio.Play();
            Destroy(other.gameObject);
            balasActual += 25;
            balasSlider.value = balasActual;
            if (balasActual >= 50)
            {
                balasActual = 50;
            }
        }
        if (other.gameObject.CompareTag("CargarEscudo"))
        {
            powerUpAudio.Play();
            Destroy(other.gameObject);
            escudoActual += 50;
            escudoSlider.value = escudoActual;
            if (escudoActual >= 100)
            {
                escudoActual = 100;
            }
        }
    }
}
