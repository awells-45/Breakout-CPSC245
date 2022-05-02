using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public GameObject ball;
    private Vector3 startingVelocity = new Vector3(100,100 ,0);
    private Vector3 lastVelocity;
    public GameObject KillBox;
    
    public void LaunchBall() 
    {
        //Subscribed to the launch input in the Input Manager
            //Change the transform of the ball based on new velocity
        //triggered by clicking start button
        RandomizeLaunchVelocity();
        ball.GetComponent<Rigidbody2D>().AddForce(startingVelocity);
    }
    
    public void PauseBall()
    {
        //Subscribed to pause input in the Input Manager
        GetLastVelocity();
        StopBall();
    }

    private void GetLastVelocity()
    {
        lastVelocity = ball.GetComponent<Rigidbody2D>().velocity;
    }

    public void UnpauseBall()
    {
        ball.GetComponent<Rigidbody2D>().velocity = lastVelocity;
    }
    
    private void KillBall()
    {
        LoseLife();
        StopBall();
        ResetBall();
    }
    
    private void LoseLife()
    {
        //Broadcasts to the Game Manager that we lost a life
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other == KillBox.GetComponent<Collider2D>())
        {
            KillBall();
        }

        /*if (other == is in an array of bricks)
        {
            BonkBrick(brick);
            IncreasePoints();
        }
        */
    } 
    
    private void StopBall()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    
    private void ResetBall()
    {
        ball.transform.position = new Vector3(0, 0 ,0);
    }
    
    public void IncreaseVelocity()
    {
        GetLastVelocity();
        ball.GetComponent<Rigidbody2D>().AddForce(10*lastVelocity);
    }
    
    public void IncreasePoints()
    {
        //Sends event out to add points to the total score
    }
    
    //public void BonkBrick(brick)
    //{
       // Sends event that the brick that was hit must be destroyed/hidden
   // }

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
        float xVelocity = xDirection*200 - xDirection*Random.value*175;
        float yVelocity = 200;
        Vector3 randomVelocity = new Vector3(xVelocity ,yVelocity);
        startingVelocity = randomVelocity;
    }

    private bool RandomizeXDirection()
    {
        if (Random.value > .5)
        {
            //positive direction
            return true;
        }
        else
        {
            //negative direction
            return false;
        }
    }
}
