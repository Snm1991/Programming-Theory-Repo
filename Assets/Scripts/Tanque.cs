using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Tanque : MonoBehaviour
{
    public ParticleSystem destruccionParticle;
    public AudioSource motorAudio;
    void Start()
    {
        motorAudio = GetComponent<AudioSource>();
    }
    protected void DetenerMotor()
    {
        motorAudio.Stop();
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
}