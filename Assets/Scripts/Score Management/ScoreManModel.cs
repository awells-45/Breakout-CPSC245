using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManModel : MonoBehaviour
{
    /*This is the model of the MVC that contains score and lives for the game
     * The model updates and changes all of the score and lives data. This then updates view
     * SCORE MAN MODEL, THIS STORES LIVES AND SCORED AND CHANGES BASED ON THAT
     */
    private ScoreManView ScoreManView;

    public delegate void GameOver(State NewState);
    public static event GameOver GameOverEvent;

    private float Score = 0.0f;
    private float DefaultIncreaseAmount = 10.0f;
    private float ScoreMultiplier = 1.0f;

    private int StartingBallLives = 3; //Starting lives, this is also what gets restarted to.
                                       //Change this if you want to increase or decrease difficulty
    private int BallLives = 0;

    public void Awake()//gets the view script
    {
        ScoreManView = GetComponent<ScoreManView>();
    }

    public void initData() //called from controller
    {
        print("Data Initalized");
        Score = 0;
        BallLives = StartingBallLives;
        ScoreManView.UpdateScoreText(Score.ToString());
        ScoreManView.UpdateLivesText(BallLives.ToString());
    }

    public void IncreaseScore()
    { //called from controller increases score and increases the multiplier
        Score = Score + DefaultIncreaseAmount * ScoreMultiplier;
        ScoreMultiplier = ScoreMultiplier + .1f;
        ScoreManView.UpdateScoreText(Score.ToString());
    }

    public void ResetScore() //Called when a life is lost and its == 0 in LoseLife()
    {
        Score = 0;
        ScoreMultiplier = 1.0f;
        BallLives = StartingBallLives;
        
        ScoreManView.UpdateScoreText(Score.ToString());
        ScoreManView.UpdateLivesText(BallLives.ToString());
    }
    public void LoseLife()
    { //called from controller resets score multiplier and decrements lives
        BallLives = BallLives - 1;
        ScoreMultiplier = 1.0f;
        if (BallLives == 0)
        {
            //Set Gamestate to lost; BROADCASTS OUT A EVENT THAT CAN BE READ TO CHANGE STATE
            if (GameOverEvent != null)
            {
                GameOverEvent(State.Lost);
            }
            else
            {
                print("Nothing is subscribed to Game Over Event In Score Model");
            }
        }
        ScoreManView.UpdateLivesText(BallLives.ToString());
    }
}
