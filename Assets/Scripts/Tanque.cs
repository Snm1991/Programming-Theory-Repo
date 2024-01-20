using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Tanque : MonoBehaviour
{
    [SerializeField] private ParticleSystem destruccionParticle;
    private int velRotacionRuedas = 2;
    //DESTRUIR EL TANQUE
    protected void DestruirTanque()
    {
        Destroy(gameObject);
    }
    //GENERAR EXPLOSION
    protected void ExplosionTanque()
    {
        Instantiate(destruccionParticle, transform.position,
        destruccionParticle.transform.rotation);
    }
    //MOVER TANQUE
    protected virtual void MoverTanque()
    {
        transform.Translate(0, 0, 1 * Time.deltaTime);
    }
    //RECIBIR DAÑO
    protected abstract void Daño();
    //DISPARAR
    protected abstract void Disparo();
    //ROTAR RUEDAS
    protected void RotarRuedas(GameObject rueda1, GameObject rueda2,
    GameObject rueda3, GameObject rueda4)
    {
        rueda1.transform.Rotate(velRotacionRuedas, 0, 0);
        rueda2.transform.Rotate(velRotacionRuedas, 0, 0);
        rueda3.transform.Rotate(velRotacionRuedas, 0, 0);
        rueda4.transform.Rotate(velRotacionRuedas, 0, 0);
    }
    
}