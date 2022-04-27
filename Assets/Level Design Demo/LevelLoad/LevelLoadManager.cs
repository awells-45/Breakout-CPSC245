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

    public int activeBricks = 0;
    public Level[] levels;
    public int currentLevel = 0;
    public ObjectPool objectPool;

    private void Awake()
    {
        objectPool = ObjectPool.sharedInstance;
    }

    public void Start()
    {
        // This is for testing, in reality LoadLevel should be called by the game manager
        //LoadLevel();
    }

    public void LoadLevel()
    {
        Level level = levels[currentLevel];
        currentLevel += 1;
        //foreach (BlueprintBrick brick in level.bricks)
        //{
         //   AddBrick(brick);
        //}
        objectPool.PlaceBricks(getBrickLocations(level), getBrickSprites(level));
        activeBricks = level.bricks.Count;
    }

    public static void AddBrick(BlueprintBrick brick)
    {
        // use the function contained in the bricks script to place the bricks
        Debug.Log(brick.brickTransform + " " + brick.brickSprite);
    }

    public void DecrementActiveBricks()
    {
        activeBricks -= 1;
        if (activeBricks == 0)
        {
            LoadLevel();
        }
    }

     private List<Vector2> getBrickLocations(Level nextLevel)
     { 
         List<Vector2> brickPositions = new List<Vector2>();
        foreach (BlueprintBrick brick in nextLevel.bricks)
        {
            brickPositions.Add(brick.GetTransform());
        }

        return brickPositions;
     }
     
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