using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilJugador : Misil //HERENCIA
{
    void Update()
    {
        //MOVER EL MISIL, SI EL JUEGO TERMINA O SALE DE LOS LIMITES DE PANTALLA, SE DESTRUYE
        MoverMisil();
        if (transform.position.z < -25 || !juegoActivo.juegoActivo)
        {
            DestruirMisil();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        DestruirMisil();
    }
    
}
