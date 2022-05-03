using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public float moveAmount;
    public PlayerInputActions playerInputs;

    private bool _gameIsPlaying = false;


    private void Awake()
    {
        playerInputs = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputs.Player.MovePaddleLeft.performed += OnLeftPress;
        playerInputs.Player.MovePaddleRight.performed += OnRightPress;
        
        playerInputs.Player.MovePaddleLeft.Enable();
        playerInputs.Player.MovePaddleRight.Enable();
    }

    public void OnLeftPress(InputAction.CallbackContext callback) 
    {
        //if(_gameIsPlaying)
            this.transform.position += Vector3.left * moveAmount;
    }

    public void OnRightPress(InputAction.CallbackContext callback) 
    {
        //if (_gameIsPlaying)
            this.transform.position += Vector3.right * moveAmount;
    }

    public void StartGame() // Triggered by EnterPlayingState or the Ball's LaunchingBall event
    {
        _gameIsPlaying = true;
    }

    public void PauseGame()  // Triggered by EnterPauseState
    {
        _gameIsPlaying = false;
    }
    
    public void StopGame() { // Triggered by EnterMainMenuState or EnterWonState or EnterLostState or the Ball's LostLife event
        _gameIsPlaying = false;
        ResetPaddle();
    }

    public void ResetPaddle() 
    {
        this.transform.position = new Vector3(0, -2.4f, 0);
    }
}
