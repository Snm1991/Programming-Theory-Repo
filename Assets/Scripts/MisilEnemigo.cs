using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilEnemigo : Misil //HERENCIA
{
    void Update()
    {
        //MOVER EL MISIL, SI EL JUEGO TERMINA, SE DESTRUYE
        MoverMisil();
        if (!juegoActivo.juegoActivo)
        {
            DestruirMisil();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        DestruirMisil();
    }
}
