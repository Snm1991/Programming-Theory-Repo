using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<GameObject> powerUpPrefabs;
    [SerializeField] private int enemyCount;
    private float startDelay = 3.0f;
    private int spawnRateEnemy;
    private int spawnRatePowerUp;
    private int ejeX = 18;
    private int ejeYEnemy = 0;
    private int ejeYPowerUp = 2;
    private int ejeZ = 13;

    void Start()
    {
        spawnRateEnemy = Random.Range(2, 10);
        spawnRatePowerUp = Random.Range(8, 16);
        InvokeRepeating("SpawnEnemy", startDelay, spawnRateEnemy);
        InvokeRepeating("SpawnPowerUp", startDelay, spawnRatePowerUp);
    }
    // Update is called once per frame
    void SpawnEnemy()
    {
        enemyCount = FindObjectsOfType<MovEnemigo>().Length;
        if (enemyCount == 0)
        {
            int index = Random.Range(0, enemyPrefabs.Count);
            Instantiate(enemyPrefabs[index], new Vector3(ejeX, ejeYEnemy, ejeZ),
            enemyPrefabs[index].transform.rotation);
        }
    }
    void SpawnPowerUp()
    {
        int index = Random.Range(0, powerUpPrefabs.Count);
        Instantiate(powerUpPrefabs[index], new Vector3(ejeX, ejeYPowerUp, ejeZ),
        powerUpPrefabs[index].transform.rotation);
    }
}
