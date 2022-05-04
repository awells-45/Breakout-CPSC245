using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManModel : MonoBehaviour
{
    /*STILL TO DO::
     * Need to implement Event braodcast when game is lost. Implementing Controller actually getting called by Outside events
     * Kinda need to combine this to actually do both of these
     */
    //SCORE MAN MODEL, THIS STORES LIVES AND SCORED AND CHANGES BASED ON THAT
    public ScoreManView ScoreManView;

    public delegate void GameOver();
    public static event GameOver GameOverEvent;

    private float Score = 0.0f;
    private float DefaultIncreaseAmount = 10.0f;
    private float ScoreMultiplier = 1.0f;

    private int StartingBallLives = 3;
    private int BallLives = 0;

    public void initData() //called from controller
    {
        print("Data Initalized");
        Score = 0;
        BallLives = StartingBallLives;
        ScoreManView.UpdateScoreText(Score.ToString());
        ScoreManView.UpdateLivesText(BallLives.ToString());
    }

    public void IncreaseScore(){ //called from controller
        Score = Score + DefaultIncreaseAmount*ScoreMultiplier;
        ScoreMultiplier = ScoreMultiplier + .1f;
        ScoreManView.UpdateScoreText(Score.ToString());
    }

    private void ResetScore() //Called when a life is lost and its == 0 in LoseLife()
    {
        Score = 0;
        BallLives = StartingBallLives;
        ScoreManView.UpdateScoreText(Score.ToString());
        ScoreManView.UpdateLivesText(BallLives.ToString());
    }
    public void LoseLife(){ //called from controller
        BallLives = BallLives - 1;
        ScoreMultiplier = 1.0f;
        if(BallLives == 0)
        {
            //Set Gamestate to lost; BROADCASTS OUT A EVENT THAT CAN BE READ TO CHANGE STATE. NEEDS TO BE IMPLEMENTED
            if (GameOverEvent != null)
            {
                GameOverEvent();
            }
            else
            {
                print("Nothing is subscribed to Game Over Event In Score Model");
            }
            ResetScore();
        }
        ScoreManView.UpdateLivesText(BallLives.ToString());
    }

}
