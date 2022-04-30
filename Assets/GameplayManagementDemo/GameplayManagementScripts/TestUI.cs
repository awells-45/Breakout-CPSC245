using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    public delegate void ChangeState(State newState);

    public static event ChangeState LoadLevel;
    public static event ChangeState Lost;
    public static event ChangeState MainMenu;
    public static event ChangeState Pause;
    public static event ChangeState Playing;
    public static event ChangeState Won;
    
    public Text TestText;

    [SerializeField]
    private Button LoadLevelButton;
    [SerializeField]
    private Button LostButton;
    [SerializeField]
    private Button MainMenuButton;
    [SerializeField]
    private Button PauseButton;
    [SerializeField]
    private Button PlayingButton;
    [SerializeField]
    private Button WonButton;

    private void Start()
    {
        LoadLevelButton.onClick.AddListener(OnLoadLevelButtonPressed);
        LostButton.onClick.AddListener(OnLostButtonPressed);
        MainMenuButton.onClick.AddListener(OnMainMenuButtonPressed);
        PauseButton.onClick.AddListener(OnPauseButtonPressed);
        PlayingButton.onClick.AddListener(OnPlayingButtonPressed);
        WonButton.onClick.AddListener(OnWonButtonPressed);
    }

    private void OnEnable()
    {
        GameStateLoadLevel.LoadLevelStateBegin += ChangeToLoadText;
        GameStateLost.LoseStateBegin += ChangeToLostText;
        GameStateMainMenu.MainMenuStateBegin += ChangeToMainMenuText;
        GameStatePaused.PauseStateBegin += ChangeToPauseText;
        GameStatePlaying.PlayingStateBegin += ChangeToPlayingText;
        GameStateWon.WonStateBegin += ChangeToWonText;
    }

    private void OnDisable()
    {
        GameStateLoadLevel.LoadLevelStateBegin -= ChangeToLoadText;
        GameStateLost.LoseStateBegin -= ChangeToLostText;
        GameStateMainMenu.MainMenuStateBegin -= ChangeToMainMenuText;
        GameStatePaused.PauseStateBegin -= ChangeToPauseText;
        GameStatePlaying.PlayingStateBegin -= ChangeToPlayingText;
        GameStateWon.WonStateBegin -= ChangeToWonText;
    }

    private void OnLoadLevelButtonPressed()
    {
        if (LoadLevel != null)
        {
            LoadLevel(State.LoadLevel);
        }
    }

    private void OnLostButtonPressed()
    {
        if (Lost != null)
        {
            Lost(State.Lost);
        }
    }

    private void OnMainMenuButtonPressed()
    {
        if (MainMenu != null)
        {
            MainMenu(State.MainMenu);
        }
    }

    private void OnPauseButtonPressed()
    {
        if (Pause != null)
        {
            Pause(State.Pause);
        }
    }

    private void OnPlayingButtonPressed()
    {
        if (Playing != null)
        {
            Playing(State.Playing);
        }
    }

    private void OnWonButtonPressed()
    {
        if (Won != null)
        {
            Won(State.Won);
        }
    }

    private void ChangeToLoadText()
    {
        TestText.text = "LoadLevel State";
    }

    private void ChangeToLostText()
    {
        TestText.text = "Lost State";
    }

    private void ChangeToMainMenuText()
    {
        TestText.text = "MainMenu State";
    }

    private void ChangeToPauseText()
    {
        TestText.text = "Pause State";
    }

    private void ChangeToPlayingText()
    {
        TestText.text = "Playing State";
    }

    private void ChangeToWonText()
    {
        TestText.text = "Won State";
    }
}
