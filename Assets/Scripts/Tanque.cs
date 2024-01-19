using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Tanque : MonoBehaviour
{
    [SerializeField] private ParticleSystem destruccionParticle;
    private int velRotacionRuedas = 2;
    protected void DestruirTanque()
    {
        Destroy(gameObject);
    }
    protected void ExplosionTanque()
    {
        Instantiate(destruccionParticle, transform.position,
        destruccionParticle.transform.rotation);
    }
    protected virtual void MoverTanque()
    {
        transform.Translate(0, 0, 1 * Time.deltaTime);
    }
    protected abstract void Daño();
    protected abstract void Disparo();
    protected void RotarRuedas(GameObject rueda1, GameObject rueda2,
    GameObject rueda3, GameObject rueda4)
    {
        rueda1.transform.Rotate(velRotacionRuedas, 0, 0);
        rueda2.transform.Rotate(velRotacionRuedas, 0, 0);
        rueda3.transform.Rotate(velRotacionRuedas, 0, 0);
        rueda4.transform.Rotate(velRotacionRuedas, 0, 0);
    }
    
}