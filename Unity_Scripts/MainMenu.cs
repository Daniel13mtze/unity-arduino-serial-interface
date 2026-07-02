using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void EscenaGame()
    {
        SceneManager.LoadScene("Jugador");

    }
    public void NoEscenaGame()
    {
        SceneManager.UnloadSceneAsync("Jugador");

    }
    public void EscenaAjustes()
    {
        SceneManager.LoadScene("Ajustes");

    }
    public void EscenaMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
    public void Salir()
    {
        Application.Quit();
    }
}
