using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionRuedas : MonoBehaviour
{
    private int rotacionRuedas = 2;
    private GameManager juegoActivo;
    void Start()
    {
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (juegoActivo.juegoActivo)
        {
            transform.Rotate(rotacionRuedas, 0, 0);
        }
    }
}
