using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPiso : MonoBehaviour
{
    private Vector3 posInicio;
    private float velocidadScroll = 1.5f;
    void Start()
    {
        posInicio = transform.position;
    }
    void Update()
    {
        Mover();
        if (transform.position.z > 6)
        {
            ResetearPosicion();
        }
    }
    void Mover()
    {
        transform.Translate(Vector3.forward * velocidadScroll * Time.deltaTime);
    }
    void ResetearPosicion()
    {
        transform.position = posInicio;
    }
}

