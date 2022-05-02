using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // Variable for each game state
    [HideInInspector] public GameStateLoadLevel LoadLevelState;
    [HideInInspector] public GameStateLost LostState;
    [HideInInspector] public GameStateMainMenu MainMenuState;
    [HideInInspector] public GameStatePaused PauseState;
    [HideInInspector] public GameStatePlaying PlayingState;
    [HideInInspector] public GameStateWon WonState;
    
    // Unity Events
    public UnityEvent EnterLostState;
    public UnityEvent EnterWonState;
    public UnityEvent EnterPauseState;
    public UnityEvent EnterPlayingState;
    public UnityEvent EnterLoadLevelState;
    public UnityEvent EnterMainMenuState;

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
    
    // added functions to be triggered by Unity events from the input controller and other scripts
    public void ChangeToLost()
    {
        ChangeToNewState(State.Lost);
    }
    
    public void ChangeToWon()
    {
        ChangeToNewState(State.Won);
    }
    
    public void ChangeToPlaying()
    {
        ChangeToNewState(State.Playing);
    }
    public void ChangeToPause()
    {
        ChangeToNewState(State.Pause);
    }
    public void ChangeToLoadLevel()
    {
        ChangeToNewState(State.LoadLevel);
    }
    public void ChangeToMainMenu()
    {
        ChangeToNewState(State.MainMenu);
    }

    private void ChangeToNewState(State newState)
    {
        currentState.OnStateExited();

        switch (newState)
        {
            case State.Lost:
                currentState = LostState;
                EnterLostState.Invoke(); // send unity event
                break;
            case State.Pause:
                currentState = PauseState;
                EnterPauseState.Invoke();
                break;
            case State.Playing:
                currentState = PlayingState;
                EnterPlayingState.Invoke();
                break;
            case State.Won:
                currentState = WonState;
                EnterWonState.Invoke();
                break;
            case State.LoadLevel:
                currentState = LoadLevelState;
                EnterLoadLevelState.Invoke();
                break;
            case State.MainMenu:
                currentState = MainMenuState;
                EnterMainMenuState.Invoke();
                break;
            default:
                Debug.Log("Error on ChangeToNewState");
                break;
        }
        
        currentState.OnStateEntered();
    }
}
