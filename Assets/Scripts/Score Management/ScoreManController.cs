using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManController : MonoBehaviour
{
    //SCORE MAN CONTROLLER, THIS CALLS THE METHODS NEEDED INI SCORE MAN MOD
    private ScoreManModel scoreManMod;

    //This needs to be called at level start. Either through event or manual call
    public void InitOnGameStart()
    {
        scoreManMod.initData();
    }
    
    public void ChangeScore()//makeshift method that links to button and increases score
    {
        scoreManMod.IncreaseScore();
    }

    public void ChangeLives()//makeshift method that links to button and decrements lives
    {
        scoreManMod.LoseLife();
    }
    //ChangeScore is a placeholder event name called fr Brick, ChangeLives is a placeholder event name called from Ball
    
    // THIS NEEDS TO PROPELY WORK AND CALLL RESPECTIVE METHODS WHEN IMPLEMENTED BASED ON PUB SUB
    private void Awake(){
        scoreManMod = GetComponent<ScoreManModel>();
        // Ball.ChangeLives += scoreManMod.LoseLife;
        scoreManMod.initData();
    }

    private void OnEnable()
    {
        Brick.ChangeScoreEvent += scoreManMod.IncreaseScore;
    }

    private void OnDisable()
    {
        Brick.ChangeScoreEvent -= scoreManMod.IncreaseScore;
    }
}
