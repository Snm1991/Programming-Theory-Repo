using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPowerUp : MonoBehaviour
{
    [SerializeField] private int vel;
    private GameManager juegoActivo;
    void Start()
    {
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (juegoActivo.juegoActivo)
        {
            transform.Translate(0, 0, vel * Time.deltaTime);
        }
    }
}
