using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionFondo : MonoBehaviour
{
    private GameManager juegoActivo;
    void Start()
    {
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (juegoActivo.juegoActivo)
        {
            transform.Rotate(0, -0.5f * Time.deltaTime, 0);
        }
    }
}
