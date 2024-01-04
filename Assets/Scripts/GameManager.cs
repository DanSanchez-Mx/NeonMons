using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    pause,
    gameOver,
    shop,
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;
    public static GameManager sharedInstance;
    private PlayerConroller controller;

    public bool gameRunning = true;

    private void Awake()
    {
        //El if solo es para asegurar que solo hay un shared Instance
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }

        /*if (GameState == GameState.shop)
        {
            gameRunning = false;
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("Player").GetComponent<PlayerConroller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.inGame)
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeGameRunningState();
        }
    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void Pause()
    {
        SetGameState(GameState.pause);
    }

    public void gameOver()
    {
        SetGameState(GameState.gameOver);
    }

    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.inGame)
        {
            // TODO: Hay que programar la escena para jugar
            //LevelManager.sharedInstance.RemoveLevelBlocks();

            // Invoca a la funcion ("ReloadLevel, despues de .1 seg)
            //Invoke("ReloadLevel", 0.1f);

            MenuManager.sharedInstance.ShowgameCanvas();
            MenuManager.sharedInstance.HaidgameOverCanvas();
            MenuManager.sharedInstance.HaidpauseCanvas();

        }
        else if (newGameState == GameState.gameOver)
        {
            // TODO: Preparar el juego para el Game Over
            MenuManager.sharedInstance.HaidgameCanvas();
            MenuManager.sharedInstance.ShowgameOverCanvas();
            MenuManager.sharedInstance.HaidpauseCanvas();
        }
        else if (newGameState == GameState.pause)
        {
            // TODO: Preparar el juego para el Game Over
            MenuManager.sharedInstance.HaidgameCanvas();
            MenuManager.sharedInstance.HaidgameOverCanvas();
            MenuManager.sharedInstance.ShowpauseCanvas();
        }

        this.currentGameState = newGameState;
    }

    public void ReloadLevel()
    {
        //LevelManager.sharedInstance.GenerateInitialBlocks();
        controller.StartGame();
    }

    // Las siguientes funciones serán para poder pausar el jueg
    // conuncambio de variables
    public void ChangeGameRunningState()
    {
        gameRunning = !gameRunning;

        if (gameRunning)
        {
            Time.timeScale = 1f;
            MenuManager.sharedInstance.HaidpauseCanvas();
            MenuManager.sharedInstance.ShowgameCanvas();

        }
        else
        {
            Time.timeScale = 0f;
            MenuManager.sharedInstance.HaidgameCanvas();
            MenuManager.sharedInstance.ShowpauseCanvas();
        }

    }
}
