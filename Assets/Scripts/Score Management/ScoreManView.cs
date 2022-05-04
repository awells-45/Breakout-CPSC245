using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManView : MonoBehaviour
{
    //SCORE MAN VIEW, THIS HAS THE UI OBJECTS FOR SCORE AND LIVES AND GETS CALLED BY MODEL
    public Text ScoreText;
    public Text LivesText;
    
    public void UpdateScoreText(string updateScore){
        ScoreText.text = updateScore;
    }
    public void UpdateLivesText(string updateLives){
        LivesText.text = updateLives;
    }

}
