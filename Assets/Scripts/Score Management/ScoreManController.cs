using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManController : MonoBehaviour
{
    /*This is the controller of the MVC that contains score and lives for the game
     *This subs and unsubs to events that then call methods in model
     *
     * SCORE MAN CONTROLLER, THIS CALLS THE METHODS NEEDED IN SCORE MAN MOD
     */
    private ScoreManModel scoreManMod;

    //This needs to be called at game start
    public void InitOnGameStart()
    {
        scoreManMod.initData();
    }

    //On Awake init's data and gets model script
    private void Awake()
    {
        scoreManMod = GetComponent<ScoreManModel>();
        //print("Init Data Called");
        scoreManMod.initData();
    }

    private void OnEnable() //subscribes to all events from diffrent scripts.
    {
        GameStateMainMenu.MainMenuStateBegin += scoreManMod.ResetScore;
        Killzone.KillBallCollision += scoreManMod.LoseLife;
        Brick.ChangeScoreEvent += scoreManMod.IncreaseScore;
    }

    private void OnDisable()//unsubscribes to all events 
    {
        GameStateMainMenu.MainMenuStateBegin -= scoreManMod.ResetScore;
        Killzone.KillBallCollision -= scoreManMod.LoseLife;
        Brick.ChangeScoreEvent -= scoreManMod.IncreaseScore;
    }
}
