using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilEnemigo : Misil
{
    void Update()
    {
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
