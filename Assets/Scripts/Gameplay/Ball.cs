using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    public PlayerInputActions playerInputs;

    public float nudgeAmount = 5;

    private float startingBallSpeed = 6.5f;

    private Vector3 startingVelocity = new Vector3(5, 5, 0);
    private Rigidbody2D rigidBody;

    private bool playPaddleSound1 = true;
    public float ballHitPositionMultiplier = 4.0f;

    private void Awake()
    {
        this.rigidBody = this.GetComponent<Rigidbody2D>();
        playerInputs = new PlayerInputActions();
    }

    public void LaunchBall(InputAction.CallbackContext callback)
    {
        //NOTE: This is a temporary solution. This fixes a bug where you can continuously press space to reset the ball's velocity
        // if (this.GetComponent<Rigidbody2D>().velocity > 0.01f)
        print("BALL LAUNCHED");
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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Boundary")
        {
            AudioManager.Instance.Play("PaddleHitWall");
        }
        CheckAndFixStuck();
    }

    private void CheckAndFixStuck() // check if ball is stuck moving horizontally or vertically, and give it a nudge if needed
    {
        if (rigidBody.velocity == Vector2.zero)
        {
            return;
        }

        if (Mathf.Abs(rigidBody.velocity.x) < 0.1f)
        {
            rigidBody.velocity = new Vector2(nudgeAmount, rigidBody.velocity.y);
        }
        if (Mathf.Abs(rigidBody.velocity.y) < 0.1f)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, nudgeAmount);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playPaddleSound1)
        {
            AudioManager.Instance.Play("PaddleHit1");
        }
        else
        {
            AudioManager.Instance.Play("PaddleHit2");
        }
        playPaddleSound1 = !playPaddleSound1;

        if (col.gameObject.tag == "PaddleSides")
        {
            rigidBody.velocity = new Vector2(-1.0f * rigidBody.velocity.x, rigidBody.velocity.y);
        }
        else if (col.gameObject.tag == "PaddleTop")
        {
            float difference = transform.position.x - col.transform.position.x;
            Debug.Log(difference);
            rigidBody.velocity = new Vector2(rigidBody.velocity.x + difference * ballHitPositionMultiplier, -3.0f);
            rigidBody.velocity = rigidBody.velocity.normalized * startingBallSpeed;

            rigidBody.velocity = new Vector2(rigidBody.velocity.x, -1.0f * rigidBody.velocity.y);
        }
        else if (col.gameObject.tag == "PaddleDiag")
        {
            rigidBody.velocity = new Vector2(-1.0f * rigidBody.velocity.x, -1.0f * rigidBody.velocity.y);
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
