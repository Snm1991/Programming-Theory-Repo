using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    private float ejeZ = 17.8f;
    private GameManager juegoActivo;
    [SerializeField] private TextMeshProUGUI cantidadEnemigosText;
    public int cantEnemigos;
    [SerializeField] private GameObject canvasMenu;
    [SerializeField] private GameObject canvasMisionCompleta;
    void Start()
    {
        spawnRateEnemy = Random.Range(2, 10);
        spawnRatePowerUp = Random.Range(10, 18);
        InvokeRepeating("SpawnEnemy", startDelay, spawnRateEnemy);
        InvokeRepeating("SpawnPowerUp", startDelay, spawnRatePowerUp);
        juegoActivo = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (juegoActivo.juegoActivo)
        {
            cantidadEnemigosText.text = "Enemigos restantes: " + cantEnemigos;
        }
        if (cantEnemigos == 0)
        {
            juegoActivo.juegoActivo = false;
            canvasMenu.SetActive(true);
            canvasMisionCompleta.SetActive(true);
        }
    }
    void SpawnEnemy()
    {
        enemyCount = FindObjectsOfType<MovEnemigo>().Length;
        if (enemyCount == 0 && cantEnemigos > 0)
        {
            int index = Random.Range(0, enemyPrefabs.Count);
            Instantiate(enemyPrefabs[index], new Vector3(ejeX, ejeYEnemy, ejeZ),
            enemyPrefabs[index].transform.rotation);
        }
    }
    void SpawnPowerUp()
    {
        if (juegoActivo.juegoActivo)
        {
            int index = Random.Range(0, powerUpPrefabs.Count);
            Instantiate(powerUpPrefabs[index], new Vector3(ejeX, ejeYPowerUp, ejeZ),
            powerUpPrefabs[index].transform.rotation);
        }
    }
}
