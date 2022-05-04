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
        throw new NotImplementedException();
    }
    
    private void OnDisable()
    {
        throw new NotImplementedException();
    }

    public void KillBall()
    {
        LoseLife();
        StopBall();
        ResetBall();
    }

    private void LoseLife() //Broadcasts to the Game Manager that we lost a life
    {
        // C# Event???
    }

    private void StopBall()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    
    private void ResetBall()
    {
        ball.transform.position = new Vector3(0, 0 ,0);
    }

    /*
    public void IncreasePoints() //Sends event out to add points to the total score - This should instead be done by the bricks!!!!!!!!!!!!!!!!!!!!
    {
        // C# Event???
    }
    */
    
    //public void BonkBrick(brick) // This should instead be done by the bricks!!!!!!!!!!!!!!!!!!!!
    //{
       // Sends event that the brick that was hit must be destroyed/hidden??????
    //}

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
