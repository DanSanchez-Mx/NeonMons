using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager sharedInstance;
    public Canvas gameCanvas;
    public Canvas pauseCanvas;
    public Canvas gameOverCanvas;


    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Funciones para mostrar u ocultar el canvas del juego
    public void ShowgameCanvas()
    {
        gameCanvas.enabled = true;
    }
    public void HaidgameCanvas()
    {
        gameCanvas.enabled = false;
    }

    // Funciones para mostrar u oculatra el canvas de la pausa
    public void ShowpauseCanvas()
    {
        pauseCanvas.enabled = true;
    }
    public void HaidpauseCanvas()
    {
        pauseCanvas.enabled = false;
    }

    // Funciones para mostrar u oculatra el canvas del Game Over
    public void ShowgameOverCanvas()
    {
        gameOverCanvas.enabled = true;
    }
    public void HaidgameOverCanvas()
    {
        gameOverCanvas.enabled = false;
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

    }
}
