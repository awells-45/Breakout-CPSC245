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
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

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

    public static LevelLoadManager sharedInstance;

    public int activeBricks = 0;
    public int numToPool;
    public Level[] levels;
    public int nextLevel = 0;
    public ObjectPool objectPool;
    public SpriteRenderer Levelbackground;
    public Sprite TestImage;
    public delegate void LoadLevelCompleted(State NewState);
    public static event LoadLevelCompleted OnLevelLoad;
    public static event LoadLevelCompleted OnAllLevelscComplete;

    private void OnEnable()
    {
        GameStateLoadLevel.LoadLevelStateBegin += LoadLevel;
        GameStateMainMenu.MainMenuStateBegin += Reset;
    }

    private void OnDisable()
    {
        GameStateLoadLevel.LoadLevelStateBegin -= LoadLevel;
        GameStateMainMenu.MainMenuStateBegin -= Reset;
    }


    // creates the object pool and sets the amount of bricks needed to pool
    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        objectPool = ObjectPool.sharedInstance;
        //objectPool = FindObjectOfType<ObjectPool>();
        objectPool.amountToPool = numToPool;
    }


    // Loads the current level, then adds 1 to nextLevel to load the next level next time
    public void LoadLevel()
    {
        Debug.Log(nextLevel);
        switch (nextLevel)
        {
            case 0:
                // Do nothing
                break;
            case 1:
                AudioManager.Instance.Play("Victory");
                AudioManager.Instance.Stop("Music");
                AudioManager.Instance.Play("MenuMainDrums");
                //AudioManager.Instance.SetVolume("MenuMainNoDrums", 0.0f);
                //AudioManager.Instance.SetVolume("MenuMainDrums", 1.0f);
                break;
            case 2:
                AudioManager.Instance.Play("Victory");
                break;
            case 3:
                AudioManager.Instance.Play("Victory");
                AudioManager.Instance.Stop("Music");
                AudioManager.Instance.Play("LaterLevels");
                //AudioManager.Instance.SetVolume("MenuMainDrums", 0.0f);
                //AudioManager.Instance.SetVolume("LaterLevels", 1.0f);
                break;
            case 4:
                AudioManager.Instance.Play("Victory");
                break;
            default:
                // should never be hit
                //Debug.LogError("Level loading is not 0-4 in index");
                break;
        }

        if (nextLevel >= levels.Length)
        {
            // nextLevel = 0;
            if (OnAllLevelscComplete != null)
            {
                AudioManager.Instance.Play("Victory");
                nextLevel = 0;
                OnAllLevelscComplete(State.Won);
            }
            return;
        }
        Level level = levels[nextLevel];
        Levelbackground.sprite = level.Background;

        Debug.Log(objectPool);
        objectPool.PlaceBricks(getBrickLocations(level), getBrickSprites(level));
        activeBricks = level.bricks.Count;

        if (OnLevelLoad != null)
        {
            OnLevelLoad(State.Playing);

        }
        nextLevel += 1;
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
        nextLevel = 0;
        //LoadLevel();
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