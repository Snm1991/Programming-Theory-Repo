using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarColor : MonoBehaviour
{
    [SerializeField] private GameObject tanque;
    [SerializeField] private GameObject torreta;
    [SerializeField] private GameObject cañon;
    [SerializeField] private Material material;
    // Start is called before the first frame update
    void Start()
    {
        ColorAleatorioTanque();
    }
    void ColorAleatorioTanque()
    {
        tanque.GetComponent<Renderer>().material.color = Random.ColorHSV();
        torreta.GetComponent<Renderer>().material.color = Random.ColorHSV();
        cañon.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
