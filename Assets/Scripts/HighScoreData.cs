using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HighScoreData
{
    public HighScoreData()
    {
        
    }

    public HighScoreData(float prevScores)
    {
        score = prevScores;
    }
        
    
    public float score;

    public void SubmitScore(float newScore)
    {
        if (score < newScore)
        {
            score = newScore;
        }
            
    }
}
