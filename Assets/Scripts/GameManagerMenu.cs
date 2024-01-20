using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class GameManagerMenu : MonoBehaviour
{
    //CARGAR LA ESCENA DE JUEGO
    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    //SALIR DE LA APP
    void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
