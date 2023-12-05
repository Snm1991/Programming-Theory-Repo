using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenarParticulas : MonoBehaviour
{
    private GameManager juegoActivo;
    [SerializeField] private ParticleSystem particulasBarro;
    void Start()
    {
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
        particulasBarro.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!juegoActivo.juegoActivo)
        {
            particulasBarro.Stop();
        }
    }
}
