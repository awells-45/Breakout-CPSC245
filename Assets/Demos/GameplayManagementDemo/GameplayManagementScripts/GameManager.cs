using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variable for each game state
    [HideInInspector] public GameStateLoadLevel LoadLevelState;
    [HideInInspector] public GameStateLost LostState;
    [HideInInspector] public GameStateMainMenu MainMenuState;
    [HideInInspector] public GameStatePaused PauseState;
    [HideInInspector] public GameStatePlaying PlayingState;
    [HideInInspector] public GameStateWon WonState;

    private GameState currentState;

    private void Awake()
    {
        LoadLevelState = new GameStateLoadLevel();
        LostState = new GameStateLost();
        MainMenuState = new GameStateMainMenu();
        PauseState = new GameStatePaused();
        PlayingState = new GameStatePlaying();
        WonState = new GameStateWon();

        currentState = MainMenuState;
    }

    private void OnEnable()
    {
        // subscribe to all events that cause state changes
        TestUI.Lost += ChangeToNewState;
        TestUI.LoadLevel += ChangeToNewState;
        TestUI.MainMenu += ChangeToNewState;
        TestUI.Pause += ChangeToNewState;
        TestUI.Playing += ChangeToNewState;
        TestUI.Won += ChangeToNewState;
    }

    private void OnDisable()
    {
        // unsubscribe to all events that cause state changes
        TestUI.Lost -= ChangeToNewState;
        TestUI.LoadLevel -= ChangeToNewState;
        TestUI.MainMenu -= ChangeToNewState;
        TestUI.Pause -= ChangeToNewState;
        TestUI.Playing -= ChangeToNewState;
        TestUI.Won -= ChangeToNewState;
    }

    private void ChangeToNewState(State newState)
    {
        currentState.OnStateExited();

        switch (newState)
        {
            case State.Lost:
                currentState = LostState;
                break;
            case State.Pause:
                currentState = PauseState;
                break;
            case State.Playing:
                currentState = PlayingState;
                break;
            case State.Won:
                currentState = WonState;
                break;
            case State.LoadLevel:
                currentState = LoadLevelState;
                break;
            case State.MainMenu:
                currentState = MainMenuState;
                break;
            default:
                Debug.Log("Error on ChangeToNewState");
                break;
        }
        
        currentState.OnStateEntered();
    }
}
