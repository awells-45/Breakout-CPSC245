using UnityEngine;

public class BallSimulator : MonoBehaviour
{
    private Brick brickToHit;
    
    private Brick chooseRandomBrick()
    {
        // chooses a random number within the amount of bricks currently active in the scene
        int ActiveBrickToChoose = Random.Range(1, ObjectPool.sharedInstance.amountActive+1);
        
        // iterates through the object pool and finds the x-th active brick 
        int currentActiveBrick = 1;
        for (int i = 0; i < ObjectPool.sharedInstance.amountToPool; ++i)
        {
            Brick currentBrick = ObjectPool.sharedInstance.pooledBricks[i];
            // if the brick is active and the current active brick count equals our randomized number, return the brick
            if (currentBrick.isActiveAndEnabled)
            {
                // if we reached the randomized brick
                if (currentActiveBrick == ActiveBrickToChoose)
                {
                    return currentBrick;
                }
                else
                {
                    currentActiveBrick++;
                }
            }
        }
        return null; // could produce an error, but theoretically shouldn't bc we've already checked for the case of no active bricks
    }


    // chooses a random active brick from the scene and simulates the ball hitting it
    public void hitRandomBrick()
    {
        // check if no active bricks in scene
        if (ObjectPool.sharedInstance.amountActive == 0)
        {
            print("No active bricks left on screen!");
        }
        else
        {
            brickToHit = chooseRandomBrick();
            //brickToHit.OnHit();
        }
        
    }
}
