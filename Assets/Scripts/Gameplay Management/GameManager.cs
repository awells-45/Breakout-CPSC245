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
        TestButtons.MainMenuStart += ChangeToNewState;
        TestButtons.MainMenuEnd += ChangeToNewState;
        TestButtons.PauseMenuStart += ChangeToNewState;
        TestButtons.PauseMenuEnd += ChangeToNewState;
        TestButtons.LoseScreenStart += ChangeToNewState;
        TestButtons.LoseScreenEnd += ChangeToNewState;
        TestButtons.WinScreenStart += ChangeToNewState;
        TestButtons.WinScreenEnd += ChangeToNewState;
    }

    // Contains all the unsubscriptions to events that will cause state transitions
    private void OnDisable()
    {
        // UNSUBSCRIPTIONS ARE NOT FOR THE DEMO
        // TestUI.Lost -= ChangeToNewState;
        // TestUI.LoadLevel -= ChangeToNewState;
        // TestUI.MainMenu -= ChangeToNewState;
        // TestUI.Pause -= ChangeToNewState;
        // TestUI.Playing -= ChangeToNewState;
        // TestUI.Won -= ChangeToNewState;
        
        TestButtons.MainMenuStart -= ChangeToNewState;
        TestButtons.MainMenuEnd -= ChangeToNewState;
        TestButtons.PauseMenuStart -= ChangeToNewState;
        TestButtons.PauseMenuEnd -= ChangeToNewState;
        TestButtons.LoseScreenStart -= ChangeToNewState;
        TestButtons.LoseScreenEnd -= ChangeToNewState;
        TestButtons.WinScreenStart -= ChangeToNewState;
        TestButtons.WinScreenEnd -= ChangeToNewState;
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
                break;
            // If pause state, change current state to PauseState
            case State.Pause:
                currentState = PauseState;
                break;
            // If playing state, change current state to PlayingState
            case State.Playing:
                currentState = PlayingState;
                break;
            // If won state, change current state to WonState
            case State.Won:
                currentState = WonState;
                break;
            // If load level state, change current state to LoadLevelState
            case State.LoadLevel:
                currentState = LoadLevelState;
                break;
            // If main menu state, change current state to MainMenuState
            case State.MainMenu:
                currentState = MainMenuState;
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