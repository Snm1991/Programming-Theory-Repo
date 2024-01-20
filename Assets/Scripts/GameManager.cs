using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Libreria para manipular escenas
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    //BOOLEANOS
    public bool juegoActivo { get; private set; } //ENCAPSULACION
    //GAMEOBJECTS
    [SerializeField] private GameObject canvasPerder;
    [SerializeField] private GameObject canvasMenu;
    [SerializeField] private GameObject canvasGanar;
    //AUDIOSOURCE
    private AudioSource contadorAudio;
    //ENTEROS
    public int cantEnemigos { get; private set; } //ENCAPSULACION
    //TEXTO
    [SerializeField] private TextMeshProUGUI cantidadEnemigosText;

    void Start()
    {
        juegoActivo = true;
        contadorAudio = GetComponent<AudioSource>();
        cantEnemigos = 15;
    }
    void Update()
    {
        //ACTUALIZAR EL TEXTO CON ENEMIGOS RESTANTES
        if (juegoActivo)
        {
            TextoEnemigosRestantes();
        }
        //GANAR JUEGO CUANDO NO QUEDAN ENEMIGOS
        if (cantEnemigos == 0)
        {
            MisionCompleta();
        }
    }
    //VOLVER A LA ESCENA PRINCIPAL
    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    //VOLVER A JUGAR
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);/*Se resetea la escena 
        cuando se toca el botón para volver a empezar*/
    }
    //TERMINAR JUEGO
    public void TerminarJuego()
    {
        canvasMenu.SetActive(true);
        juegoActivo = false;
    }
    //RESTAR ENEMIGO
    public void DescontarEnemigo()
    {
        cantEnemigos -= 1;
        contadorAudio.Play();
    }
    //MOSTRAR TEXTO CON NUMERO DE ENEMIGOS
    void TextoEnemigosRestantes()
    {
        cantidadEnemigosText.text = "Enemigos restantes: " + cantEnemigos;
    }
    //GANAR JUEGO
    void MisionCompleta()
    {
        juegoActivo = false;
        canvasMenu.SetActive(true);
        canvasGanar.SetActive(true);
    }
    //SALIR DEL JUEGO
    void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
