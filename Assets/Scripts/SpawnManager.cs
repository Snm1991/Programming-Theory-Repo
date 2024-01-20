using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    //GAMEOBJECT
    [SerializeField] private GameObject enemyPrefab;
    //LISTA
    [SerializeField] private List<GameObject> powerUpPrefabs;
    //VARIABLE INT
    private int buscadorEnemigo;
    private int spawnRateEnemy;
    private int spawnRatePowerUp;
    private int ejeX = 18;
    private int ejeYEnemy = 0;
    private int ejeYPowerUp = 2;
    //VARIABLE FLOAT
    private float startDelay = 3.0f;
    private float ejeZ = 17.8f;
    //VARIABLE TIPO SCRIPT
    private GameManager juegoActivo;
    void Start()
    {
        //SE SPAWNEAN ENEMIGOS Y POWER UPS DE FORMA ALEATORIA
        spawnRateEnemy = Random.Range(2, 10);
        spawnRatePowerUp = Random.Range(8, 16);
        InvokeRepeating("SpawnEnemy", startDelay, spawnRateEnemy);
        InvokeRepeating("SpawnPowerUp", startDelay, spawnRatePowerUp);
        //SE TRAE COMPONENTE DE GAME OBJECT
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    //SPAWNEAR ENEMIGO
    void SpawnEnemy()
    {
        //SI NO SE ENCUENTRAN ENEMIGOS EN LA ESCENA, SE SPAWNEA 1
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
    //SPAWNEAR POWER UP
    void SpawnPowerUp()
    {
        int index = Random.Range(0, powerUpPrefabs.Count);
        Instantiate(powerUpPrefabs[index], new Vector3(ejeX, ejeYPowerUp, ejeZ),
        powerUpPrefabs[index].transform.rotation);
    }
}