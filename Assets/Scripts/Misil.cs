using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Misil : MonoBehaviour
{
    protected GameManager juegoActivo;
    void Start()
    {
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    protected void DestruirMisil()
    {
        Destroy(gameObject);
    }
    protected void MoverMisil()
    {
        transform.Translate(0, 0, 8 * Time.deltaTime);
    }
}
