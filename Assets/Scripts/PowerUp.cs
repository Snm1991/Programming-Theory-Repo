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
        //SI EL JUEGO ESTA ACTIVO, SE MUEVE Y ROTA EL POWER UP
        if (juegoActivo.juegoActivo)
        {
            Mover();
            Rotar();
        }
        //SI NO, SE DESTRUYE
        if (!juegoActivo.juegoActivo)
        {
            Destruir();
        }
    }
    //MOVER
    void Mover()
    {
        transform.Translate(0, 0, vel * Time.deltaTime);
    }
    //ROTAR
    void Rotar()
    {
        transform.Rotate(0, 0, rotacionpowerUp * Time.deltaTime);
    }
    //DESTRUIR
    void Destruir()
    {
        Destroy(gameObject);
    }
}
