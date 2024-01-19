using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<GameObject> powerUpPrefabs;
    private int buscadorEnemigo;
    private float startDelay = 3.0f;
    private int spawnRateEnemy;
    private int spawnRatePowerUp;
    private int ejeX = 18;
    private int ejeYEnemy = 0;
    private int ejeYPowerUp = 2;
    private float ejeZ = 17.8f;
    private GameManager juegoActivo;
    void Start()
    {
        spawnRateEnemy = Random.Range(2, 10);
        spawnRatePowerUp = Random.Range(8, 16);
        InvokeRepeating("SpawnEnemy", startDelay, spawnRateEnemy);
        InvokeRepeating("SpawnPowerUp", startDelay, spawnRatePowerUp);
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void SpawnEnemy()
    {
        if (juegoActivo.juegoActivo)
        {
            buscadorEnemigo = GameObject.FindGameObjectsWithTag("Enemigo").Length;
            if (buscadorEnemigo == 0 && juegoActivo.cantEnemigos > 0)
            {
                Instantiate(enemyPrefab, new Vector3(ejeX, ejeYEnemy, ejeZ),
                enemyPrefab.transform.rotation);
            }
        }
    }
    void SpawnPowerUp()
    {
        int index = Random.Range(0, powerUpPrefabs.Count);
        Instantiate(powerUpPrefabs[index], new Vector3(ejeX, ejeYPowerUp, ejeZ),
        powerUpPrefabs[index].transform.rotation);
    }
}