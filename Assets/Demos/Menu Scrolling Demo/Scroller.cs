using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Scroller : MonoBehaviour
{
    enum SelectedButton
    {
        Start,
        Quit
    }
    
    public UnityEvent StartGame;
    public UnityEvent QuitGame;
    
    public GameObject startButton;
    public GameObject quitButton;

    public Sprite startButtonSprite;
    public Sprite startButtonHighlightedSprite;
    public Sprite quitButtonSprite;
    public Sprite quitButtonHighlightedSprite;

    private SelectedButton _selectedButton;

    void Start()
    {
        SelectButton(SelectedButton.Start);
    }

    private void SelectButton(SelectedButton selectedButton)
    {
        _selectedButton = selectedButton;
        switch (selectedButton)
        {
            case SelectedButton.Start:
            {
                startButton.GetComponent<SpriteRenderer>().sprite = startButtonHighlightedSprite;
                break;
            }
            case SelectedButton.Quit:
            {
                quitButton.GetComponent<SpriteRenderer>().sprite = quitButtonHighlightedSprite;
                break;
            }
        }
    }
    
    private void DeselectButton(SelectedButton selectedButton)
    {
        switch (selectedButton)
        {
            case SelectedButton.Start:
            {
                startButton.GetComponent<SpriteRenderer>().sprite  = startButtonSprite;
                break;
            }
            case SelectedButton.Quit:
            {
                quitButton.GetComponent<SpriteRenderer>().sprite = quitButtonSprite;
                break;
            }
        }
    }

    public void ChangeSelectedMenuButton() // triggered by up or down UserInput event
    {
        switch (_selectedButton)
        {
            case SelectedButton.Start:
            {
                SelectButton(SelectedButton.Quit);
                DeselectButton(SelectedButton.Start);
                break;
            }
            case SelectedButton.Quit:
            {
                SelectButton(SelectedButton.Start);
                DeselectButton(SelectedButton.Quit);
                break;
            }
        }
    }

    public void EnterSelectedButton() // triggered by enter UserInput event
    {
        switch (_selectedButton)
        {
            case SelectedButton.Start:
            {
                StartGame.Invoke();
                break;
            }
            case SelectedButton.Quit:
            {
                QuitGame.Invoke();
                break;
            }
        }
    }
}
