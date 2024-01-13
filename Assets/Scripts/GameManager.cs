using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Libreria para manipular escenas
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public bool juegoActivo;
    [SerializeField] private GameObject canvasPerder;
    [SerializeField] private AudioSource contadorAudio;
    public int cantEnemigos;
    [SerializeField] private TextMeshProUGUI cantidadEnemigosText;
    [SerializeField] private GameObject canvasMenu;
    [SerializeField] private GameObject canvasMisionCompleta;
    void Start()
    {
        juegoActivo = true;
        contadorAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (juegoActivo)
        {
            TextoEnemigosRestantes();
        }
        if (cantEnemigos == 0)
        {
            MisionCompleta();
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);/*Se resetea la escena 
        cuando se toca el botón para volver a empezar*/
    }
    public void TerminarJuego()
    {
        canvasPerder.SetActive(true);
        juegoActivo = false;
    }
    public void DescontarEnemigo()
    {
        cantEnemigos -= 1;
        contadorAudio.Play();
    }
    void TextoEnemigosRestantes()
    {
        cantidadEnemigosText.text = "Enemigos restantes: " + cantEnemigos;
    }
    void MisionCompleta()
    {
        juegoActivo = false;
        canvasMenu.SetActive(true);
        canvasMisionCompleta.SetActive(true);
    }
}
