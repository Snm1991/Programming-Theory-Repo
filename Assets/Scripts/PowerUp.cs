using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private int vel = 4;
    private GameManager juegoActivo;
    private int rotacionpowerUp = 2;
    void Start()
    {
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (juegoActivo.juegoActivo)
        {
            Mover();
            Rotar();
        }
        if (!juegoActivo.juegoActivo)
        {
            Destruir();
        }
    }
    void Mover()
    {
        transform.Translate(0, 0, vel * Time.deltaTime);
    }
    void Rotar()
    {
        transform.Rotate(0, 0, rotacionpowerUp * Time.deltaTime);
    }
    void Destruir()
    {
        Destroy(gameObject);
    }
}
