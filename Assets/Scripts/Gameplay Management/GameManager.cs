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

    private void Start()
    {
        currentState.OnStateEntered();
        //AudioManager.Instance.Play("MenuMainNoDrums");
        //AudioManager.Instance.Play("MenuMainDrums");
        //AudioManager.Instance.Play("LaterLevels");
        
        //AudioManager.Instance.SetVolume("MenuMainDrums", 0.0f);
        //AudioManager.Instance.SetVolume("LaterLevels", 0.0f);
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
        // TestButtons.LoseScreenEnd += ChangeToNewState;
        TestButtons.WinScreenStart += ChangeToNewState;
        // TestButtons.WinScreenEnd += ChangeToNewState;
        LevelLoadManager.OnLevelLoad += ChangeToNewState;
        LevelLoadManager.OnAllLevelscComplete += ChangeToNewState;
        ScoreManModel.GameOverEvent += ChangeToNewState;
        ObjectPool.OnObjectPoolEmpty += ChangeToNewState;
        Pause.OnPause += ChangeToNewState;
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
        // TestButtons.LoseScreenEnd -= ChangeToNewState;
        TestButtons.WinScreenStart -= ChangeToNewState;
        // TestButtons.WinScreenEnd -= ChangeToNewState;
        LevelLoadManager.OnLevelLoad -= ChangeToNewState;
        LevelLoadManager.OnAllLevelscComplete -= ChangeToNewState;
        ScoreManModel.GameOverEvent -= ChangeToNewState;
        ObjectPool.OnObjectPoolEmpty -= ChangeToNewState;
        Pause.OnPause -= ChangeToNewState;
    }

    // Returns current state
    public bool IsMainMenu()
    {
        return currentState == MainMenuState;
    }

    // Method that takes in an enum relaying to each state, checks the enum, and changes to the current state
    private void ChangeToNewState(State newState)
    {
        // Call the current state's OnExitEvent
        currentState.OnStateExited();
        
        Time.timeScale = 0.0f; // freeze the game
        
        

        // Switch statement to check the enum
        switch (newState)
        {
            // If lose state, change current state to LostState
            case State.Lost:
                Debug.Log("Enter lost state");
                currentState = LostState;
                break;
            // If pause state, change current state to PauseState
            case State.Pause:
                Debug.Log("Enter pause state");
                currentState = PauseState;
                break;
            // If playing state, change current state to PlayingState
            case State.Playing:
                Time.timeScale = 1.0f; // unfreeze the game
                Debug.Log("Enter playing state");
                currentState = PlayingState;
                break;
            // If won state, change current state to WonState
            case State.Won:
                Debug.Log("Enter won state");
                currentState = WonState;
                break;
            // If load level state, change current state to LoadLevelState
            case State.LoadLevel:
                Debug.Log("Enter load level state");
                currentState = LoadLevelState;
                break;
            // If main menu state, change current state to MainMenuState
            case State.MainMenu:
                Debug.Log("Enter main menu state");
                currentState = MainMenuState;
                // Play the main menu song
                //AudioManager.Instance.SetVolume("MenuMainNoDrums", 1.0f);
                //AudioManager.Instance.SetVolume("MenuMainDrums", 0.0f);
                //AudioManager.Instance.SetVolume("LaterLevels", 0.0f);
                AudioManager.Instance.Stop("Music");
                AudioManager.Instance.Play("MenuMainNoDrums");
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
