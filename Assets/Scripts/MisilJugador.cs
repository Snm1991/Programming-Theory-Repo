using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilJugador : Misil
{
    void Update()
    {
        MoverMisil();
        if (transform.position.z < -25 || !juegoActivo.juegoActivo)
        {
            DestruirMisil();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        /*if (other.gameObject.CompareTag("Enemigo"))
        {
            Colision();
        }*/
        DestruirMisil();
    }
    
}
