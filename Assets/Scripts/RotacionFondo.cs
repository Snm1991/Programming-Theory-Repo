using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionFondo : MonoBehaviour
{
    private float rotacion = -0.5f;
    void Update()
    {
        RotarFondo();
    }
    //ROTAR EL FONDO DE MONTAÑAS
    void RotarFondo()
    {
        transform.Rotate(0, rotacion * Time.deltaTime, 0);
    }
}
