using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPiso : MonoBehaviour
{
    private Vector3 posInicio;
    private float velocidadScroll = 1.5f;
    private GameManager juegoActivo;
    void Start()
    {
        posInicio = transform.position;
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (juegoActivo.juegoActivo)
        {
            transform.Translate(Vector3.forward * velocidadScroll * Time.deltaTime);
            if (transform.position.z > 6)
            {
                transform.position = posInicio;
            }
        }
    }
}
