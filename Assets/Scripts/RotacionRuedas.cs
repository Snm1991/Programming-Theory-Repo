using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionRuedas : MonoBehaviour
{
    private int rotacionRuedas = 2;
    void Update()
    {
        transform.Rotate(rotacionRuedas, 0, 0);
    }
}
