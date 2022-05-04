using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public GameObject ball;
    private Vector3 startingVelocity = new Vector3(5,5 ,0);
    public GameObject KillBox;

    public void LaunchBall()
    {
        RandomizeLaunchVelocity();
        ball.GetComponent<Rigidbody2D>().velocity = startingVelocity;
    }

    private void OnEnable()
    {
        GameStateLoadLevel.LoadLevelStateBegin += KillBall;
        Killzone.KillBallCollision += KillBall;
    }
    
    private void OnDisable()
    {
        GameStateLoadLevel.LoadLevelStateBegin -= KillBall;
        Killzone.KillBallCollision -= KillBall;
    }

    public void KillBall()
    {
        StopBall();
        ResetBall();
    }

    private void StopBall()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    
    private void ResetBall()
    {
        ball.transform.position = new Vector3(0, 0 ,0);
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
        float xVelocity = xDirection*4 - xDirection*Random.value*1.75f;
        float yVelocity = 4;
        Vector3 randomVelocity = new Vector3(xVelocity ,yVelocity);
        startingVelocity = randomVelocity;
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
