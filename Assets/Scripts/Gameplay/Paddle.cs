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
        playerInputs.Player.MovePaddleLeft.performed += OnLeftPress;
        playerInputs.Player.MovePaddleLeft.canceled += OnLeftPress;
        playerInputs.Player.MovePaddleRight.performed += OnRightPress;
        playerInputs.Player.MovePaddleRight.canceled += OnRightPress;
        
        playerInputs.Player.MovePaddleLeft.Enable();
        playerInputs.Player.MovePaddleRight.Enable();
    }

    public void OnLeftPress(InputAction.CallbackContext callback) 
    {
        if (callback.canceled) {
            this.rigidBody.velocity = Vector2.zero;
        }
        else if (callback.performed) {
            this.rigidBody.velocity -= new Vector2(moveSpeed, 0);
        }
    }

    public void OnRightPress(InputAction.CallbackContext callback) 
    {
        if (callback.canceled) {
            this.rigidBody.velocity = Vector2.zero;
        }
        else if (callback.performed) {
            this.rigidBody.velocity += new Vector2(moveSpeed, 0);
        }
    }

    public void ResetPaddle() 
    {
        this.transform.position = new Vector3(0, -2.4f, 0);
    }
}
