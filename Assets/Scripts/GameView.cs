using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public Text scoreText, highScoreText;

    private float score;
    private float highScore;

    private PlayerConroller controller;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        controller = GameObject.FindWithTag("Player").GetComponent<PlayerConroller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score > highScore)
            Save();

        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            score = controller.GetTravelDistance();

            scoreText.text      = score.ToString("0");
            highScoreText.text  = highScore.ToString("0");
        }
    }

    void Save()
    {
        PlayerPrefs.SetFloat("HighScore", score);

        highScore = score;
        highScoreText.text = "" + highScore.ToString("0");
    }
}
