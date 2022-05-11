using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public float moveSpeed = 2.0f; 
    public PlayerInputActions playerInputs;
    
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        playerInputs = new PlayerInputActions();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerInputs.Player.MovePaddle.Enable();

        GameStateLoadLevel.LoadLevelStateBegin += ResetPaddle;
        Killzone.KillBallCollision += ResetPaddle;
    }

    private void OnDisable()
    {
        playerInputs.Player.MovePaddle.Disable();

        GameStateLoadLevel.LoadLevelStateBegin -= ResetPaddle;
        Killzone.KillBallCollision -= ResetPaddle;
    }

    private void FixedUpdate()
    {
        this.rigidBody.velocity = playerInputs.Player.MovePaddle.ReadValue<Vector2>() * moveSpeed;
    }
    
    public void ResetPaddle() 
    {
        this.transform.position = new Vector3(0, -2.82f, 0);
    }
}
