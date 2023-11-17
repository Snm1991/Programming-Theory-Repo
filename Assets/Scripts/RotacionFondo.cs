using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionFondo : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, -0.5f * Time.deltaTime, 0);
    }
}
