using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionFondo : MonoBehaviour
{
    private GameManager juegoActivo;
    private float rotacion = -0.5f;
    void Start()
    {
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (juegoActivo.juegoActivo)
        {
            RotarFondo();
        }
    }
    void RotarFondo()
    {
        transform.Rotate(0, rotacion * Time.deltaTime, 0);
    }
}
