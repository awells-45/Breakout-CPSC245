using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManView : MonoBehaviour
{
    //SCORE MAN VIEW, THIS HAS THE UI OBJECTS FOR SCORE AND LIVES AND GETS CALLED BY MODEL
    public Text ScoreText;
    public Text LivesText;
    public Text WinGameScoreText;
    public Text LoseGameScoreText;
    
    public void UpdateScoreText(string updateScore){//updates score text(s) with int
        ScoreText.text = updateScore;
        WinGameScoreText.text = updateScore;
        LoseGameScoreText.text = updateScore;
    }
    public void UpdateLivesText(string updateLives){//updates lives text with int
        LivesText.text = updateLives;
    }

}
