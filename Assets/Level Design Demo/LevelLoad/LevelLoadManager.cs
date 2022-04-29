/* a. Ian Reafsnyder, Lucas Torti, and Natalie Huante
 * b. 2337621, 2351555, 2374481
 * c. ireafsnyder@chapman.edu, torti@chapman.edu, huante@chapman.edu
 * d. CPSC 245-01
 * e. Brick buster class project
 *
 * Manages the loading and resetting of levels in the game.
 * Contains an array containing all levels in the game.
 */

//Created by Ian Reafsnyder and Lucas Torti
//Overall purpose: Contains a list of levels and loads the levels when the previous level has been completed.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LevelLoadManager : MonoBehaviour
{
    //https://www.youtube.com/watch?v=CPKAgyp8cno&t=660s
    public static LevelLoadManager instance;


    //Create Unity event
    public delegate void LevelCompleted();
    public static event LevelCompleted OnLevelCompleted;
    // In order to use this, place the following code in your script's Awake/Start method:
    // LevelCompleted.OnLevelCompleted += yourFunctionHere;
    // Once above code is added, "yourFunctionHere" will be called every time the "OnLevelCompleted" event occurs

    public int activeBricks = 0;
    public Level[] levels;
    public int currentLevel = 0;
    public ObjectPool objectPool;

    // Loads the current level, then adds 1 to currentLevel to load the next level next time
    public void LoadLevel()
    {
        Debug.Log(currentLevel);
        Level level = levels[currentLevel];
        currentLevel += 1;
        //foreach (BlueprintBrick brick in level.bricks)
        //{
        //   AddBrick(brick);
        //}
        Debug.Log(objectPool);
        objectPool.PlaceBricks(getBrickLocations(level), getBrickSprites(level));
        activeBricks = level.bricks.Count;
    }

    // Decrements the amount of active bricks (presumably when a brick gets hit)
    // Writes to the log when the amount of active bricks has hit 0
    public void DecrementActiveBricks()
    {
        activeBricks -= 1;
        if (activeBricks == 0)
        {
            // NOTE: This is a temporary solution. We put this here because we do not know
            // how the game manager team wants level completion implemented, though this provides a base.
            Debug.Log("There are no more bricks!");
            OnLevelCompleted();
        }
    }

    // Sets all bricks to inactive, resets the current level to 0, and loads level 0
    public void Reset()
    {
        objectPool.Reset();
        currentLevel = 0;
        LoadLevel();
    }

    // Goes through each brick in the level and creates a list of their positions, then returns that list
    // Used in level loading to assign locations to object-pooled bricks
    private List<Vector2> getBrickLocations(Level nextLevel)
    {
        List<Vector2> brickPositions = new List<Vector2>();
        foreach (BlueprintBrick brick in nextLevel.bricks)
        {
            brickPositions.Add(brick.GetTransform());
        }

        return brickPositions;
    }

    // Goes through each brick in the level and creates a list of their sprites, then returns that list
    // Used in level loading to assign sprites to object-pooled bricks
    private List<Sprite> getBrickSprites(Level nextLevel)
    {
        List<Sprite> brickSprites = new List<Sprite>();
        foreach (BlueprintBrick brick in nextLevel.bricks)
        {
            brickSprites.Add(brick.GetSprite());
        }

        return brickSprites;
    }

}