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
    [SerializeField] private float disparoSiguiente;
    private float disparo = 0.5f;
    [SerializeField] public ParticleSystem destruccionParticle;
    private int escudoInicial = 100;
    private int escudoActual;
    private int dañoEnemigo = 10;
    [SerializeField] private Slider escudoSlider;
    private int balasInicial = 50;
    private int balasActual;
    [SerializeField] private Slider balasSlider;

    void Start()
    {
        escudoActual = escudoInicial;
        balasActual = balasInicial;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > disparoSiguiente && balasActual > 0)
        {
            Instantiate(proyectilPrefab,
            new Vector3(focalPoint.transform.position.x, focalPoint.transform.position.y,
            focalPoint.transform.position.z),
            proyectilPrefab.transform.rotation);
            disparoSiguiente = Time.time + disparo;
            fireParticle.Play();
            balasActual -= 1;
            balasSlider.value = balasActual;
            if (balasActual <= 0)
            {
                balasActual = 0;
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MisilEnemy"))
        {
            explosionParticles.Play();
            escudoActual -= dañoEnemigo;
            //descuenta vida en la cantidad infringida(Ver próx. Script: Damage)
            escudoSlider.value = escudoActual;
            if (escudoActual <= 0)
            {
                escudoActual = 0;
                Destroy(gameObject);
                Instantiate(destruccionParticle, transform.position,
                destruccionParticle.transform.rotation);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CargarBalas"))
        {
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
