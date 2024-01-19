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
    public bool juegoActivo { get; private set; }
    //GAMEOBJECTS
    [SerializeField] private GameObject canvasPerder;
    [SerializeField] private GameObject canvasMenu;
    [SerializeField] private GameObject canvasGanar;
    //AUDIOSOURCE
    private AudioSource contadorAudio;
    //ENTEROS
    public int cantEnemigos { get; private set; }
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
        if (juegoActivo)
        {
            TextoEnemigosRestantes();
        }
        if (cantEnemigos == 0)
        {
            MisionCompleta();
        }
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);/*Se resetea la escena 
        cuando se toca el botón para volver a empezar*/
    }
    public void TerminarJuego()
    {
        canvasMenu.SetActive(true);
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
        canvasGanar.SetActive(true);
    }
    void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
