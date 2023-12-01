using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirParticula : MonoBehaviour
{
    [SerializeField] int tiempoParaDestruir;
    void Start()
    {
        Destroy(gameObject, tiempoParaDestruir);/*Destruir la particula después del 
        tiempo que establece la variable (pasado por inspector)*/
    }
}
