using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    private HighScoreData data;
    public Text highscoreDisplay;
    public Timer timer;
    public SaveHighScoreToFile saveSystem;

    public void Start()
    {
        GameStarted();
        HighScoreData highscrore = saveSystem.Load();
        data = new HighScoreData(highscrore.score);
        highscoreDisplay.text = "Highscore = " + data.score;
    }

    public void GameStarted()
    {
        timer.StartTimer();
    }
    public void GameWon()
    {
        float timerScore = timer.StopTimer();
        data.SubmitScore(timerScore);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            saveSystem.Save(data);
            highscoreDisplay.text = "Highscore = " + data.score;
        }
    }
}
