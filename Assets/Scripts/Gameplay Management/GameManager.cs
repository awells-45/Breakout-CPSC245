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

    // Variable that contains the current game state
    private GameState currentState;

    private void Awake()
    {
        // Creates and sets new game state to each state variable
        LoadLevelState = new GameStateLoadLevel();
        LostState = new GameStateLost();
        MainMenuState = new GameStateMainMenu();
        PauseState = new GameStatePaused();
        PlayingState = new GameStatePlaying();
        WonState = new GameStateWon();

        // Set current state to main menu as should be the first state entered upon game start
        currentState = MainMenuState;
    }

    // Contains the subscriptions to events that will cause state transitions, Ex: PlayButtonIsPressed in MainMenu
    private void OnEnable()
    {
        // SUBSCRIPTIONS ARE FOR THE DEMO
        TestUI.Lost += ChangeToNewState;
        TestUI.LoadLevel += ChangeToNewState;
        TestUI.MainMenu += ChangeToNewState;
        TestUI.Pause += ChangeToNewState;
        TestUI.Playing += ChangeToNewState;
        TestUI.Won += ChangeToNewState;
    }

    // Contains all the unsubscriptions to events that will cause state transitions
    private void OnDisable()
    {
        // UNSUBSCRIPTIONS ARE NOT FOR THE DEMO
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

    // Method that takes in an enum relaying to each state, checks the enum, and changes to the current state
    private void ChangeToNewState(State newState)
    {
        // Call the current state's OnExitEvent
        currentState.OnStateExited();

        // Switch statement to check the enum
        switch (newState)
        {
            // If lose state, change current state to LostState
            case State.Lost:
                currentState = LostState;
                EnterLostState.Invoke(); // send unity event
                break;
            // If pause state, change current state to PauseState
            case State.Pause:
                currentState = PauseState;
                EnterPauseState.Invoke();
                break;
            // If playing state, change current state to PlayingState
            case State.Playing:
                currentState = PlayingState;
                EnterPlayingState.Invoke();
                break;
            // If won state, change current state to WonState
            case State.Won:
                currentState = WonState;
                EnterWonState.Invoke();
                break;
            // If load level state, change current state to LoadLevelState
            case State.LoadLevel:
                currentState = LoadLevelState;
                EnterLoadLevelState.Invoke();
                break;
            // If main menu state, change current state to MainMenuState
            case State.MainMenu:
                currentState = MainMenuState;
                EnterMainMenuState.Invoke();
                break;
            // Should never occur, but if reaches default log an error
            default:
                Debug.LogError("Error on ChangeToNewState");
                break;
        }
        
        // Call the current state's OnEnterEvent
        currentState.OnStateEntered();
    }
}
