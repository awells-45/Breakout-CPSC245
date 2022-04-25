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

    public void Start()
    {
        // This is for testing, in reality LoadLevel should be called by the game manager
        //LoadLevel();
    }

    public void LoadLevel()
    {
        Level level = levels[currentLevel];
        currentLevel += 1;
        foreach (BlueprintBrick brick in level.bricks)
        {
            AddBrick(brick);
        }
        activeBricks = level.bricks.Count;
    }

    public static void AddBrick(BlueprintBrick brick)
    {
        // use the function contained in the bricks script to place the bricks
        Debug.Log(brick.brickTransform + " " + brick.color);
    }

    public void DecrementActiveBricks()
    {
        activeBricks -= 1;
        if (activeBricks == 0)
        {
            LoadLevel();
        }
    }
}