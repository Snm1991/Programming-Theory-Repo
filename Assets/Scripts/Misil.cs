using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Misil : MonoBehaviour
{
    public GameManager juegoActivo;
    //public AudioSource explosionAudio;
    void Start()
    {
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
        //explosionAudio = GameObject.Find("ParticulaFuego").GetComponent<AudioSource>();
    }
    public void DestruirMisil()
    {
        Destroy(gameObject);
    }
    protected void MoverMisil()
    {
        transform.Translate(0, 0, 8 * Time.deltaTime);
    }
}
