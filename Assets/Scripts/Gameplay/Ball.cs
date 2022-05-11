using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    public PlayerInputActions playerInputs;
    private float startingBallSpeed = 6.5f;

    private Vector3 startingVelocity = new Vector3(5, 5, 0);
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        this.rigidBody = this.GetComponent<Rigidbody2D>();
        playerInputs = new PlayerInputActions();
    }

    public void LaunchBall(InputAction.CallbackContext callback)
    {
        //NOTE: This is a temporary solution. This fixes a bug where you can continuously press space to reset the ball's velocity
        // if (this.GetComponent<Rigidbody2D>().velocity > 0.01f)
        if (Mathf.Abs(rigidBody.velocity.x) + Mathf.Abs(rigidBody.velocity.y) > 0.01f)
        {
            return;
        }

        if (Time.timeScale < 0.9f) // check that game is not frozen
        {
            return;
        }
        RandomizeLaunchVelocity();

        rigidBody.velocity = startingVelocity;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PaddleSides")
        {
            rigidBody.velocity = new Vector2(-1 * rigidBody.velocity.x, rigidBody.velocity.y);
        }
        else if (col.gameObject.tag == "PaddleTop")
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, -1 * rigidBody.velocity.y);
        }
    }

    private void OnEnable()
    {
        GameStateLoadLevel.LoadLevelStateBegin += KillBall;
        Killzone.KillBallCollision += KillBall;
        playerInputs.Player.LaunchBall.performed += LaunchBall;

        playerInputs.Player.LaunchBall.Enable();
    }

    private void OnDisable()
    {
        GameStateLoadLevel.LoadLevelStateBegin -= KillBall;
        Killzone.KillBallCollision -= KillBall;
        playerInputs.Player.LaunchBall.performed -= LaunchBall;

        playerInputs.Player.LaunchBall.Disable();
    }

    public void KillBall()
    {
        StopBall();
        ResetBall();
    }

    private void StopBall()
    {
        rigidBody.velocity = Vector2.zero;
    }

    private void ResetBall()
    {
        this.transform.position = new Vector3(0, -1.92f, 0);
    }

    private void RandomizeLaunchVelocity()
    {
        bool xDirectionBool = RandomizeXDirection();
        float xDirection;
        if (xDirectionBool)
        {
            xDirection = 1;
        }
        else
        {
            xDirection = -1;
        }
        float xVelocity = xDirection * 4 - xDirection * Random.value * 1.75f;
        float yVelocity = 4;
        Vector3 randomVelocity = new Vector3(xVelocity, yVelocity);
        startingVelocity = randomVelocity.normalized * startingBallSpeed;
    }

    private bool RandomizeXDirection()
    {
        if (Random.value > .5) //positive direction
        {
            return true;
        }
        else //negative direction
        {
            return false;
        }
    }
}
