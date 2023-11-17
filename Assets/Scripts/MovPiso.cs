using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPiso : MonoBehaviour
{
    private Vector3 posInicio;
    private float velocidadScroll = 0.5f;
    void Start()
    {
        posInicio = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * velocidadScroll * Time.deltaTime);
        if (transform.position.z > 6)
        {
            transform.position = posInicio;
        }
    }
}
