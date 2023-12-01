using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPowerUp : MonoBehaviour
{
    [SerializeField] private int vel;
    void Update()
    {
        transform.Translate(0, 0, vel * Time.deltaTime);
    }
}
