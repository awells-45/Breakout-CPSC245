/* a. Ian Reafsnyder, Lucas Torti, and Natalie Huante
 * b. 2337621, 2351555, 2374481
 * c. ireafsnyder@chapman.edu, torti@chapman.edu, huante@chapman.edu
 * d. CPSC 245-01
 * e. Brick buster class project
 *
 * Manages the loading and resetting of levels in the game.
 * Contains an array containing all levels in the game.
 */

//Created by Natalie Huante
//Overall purpose: Maintains and manages a pool of brick objects for increased computational efficiency

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool sharedInstance;
    public List<Brick> pooledBricks;
    public Brick objectToPool;
    public Brick objectToPlace;
    public int amountToPool;
    public int amountActive;


    // creates a singleton named sharedInstance
    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        // create the pool of Bricks needed in the game
        pooledBricks = new List<Brick>();
        Brick temp;
        for (int i = 0; i < amountToPool; ++i)
        {
            temp = Instantiate(objectToPool); // instantiate a new brick
            temp.gameObject.SetActive(false); // set it to inactive
            pooledBricks.Add(temp); // add to the object pool 
            print("made brick: " + (i + 1));
        }
    }

    // sets all the brick objects to be inactive, and updates the relevant amountActive value to be 0
    public void Reset()
    {
        // resets all bricks to inactive
        for (int i = 0; i < amountToPool; ++i)
        {
            pooledBricks[i].gameObject.SetActive(false);
        }

        amountActive = 0;
    }

    // return the next available brick which is not currently in use
    private Brick GetPooledObject()
    {
        for (int i = 0; i < amountToPool; ++i)
        {
            if (!(pooledBricks[i].isActiveAndEnabled))
            {
                return pooledBricks[i];
            }
        }
        return null;
    }

    // given a list of positions and images, places the bricks accordingly and increments 
    //amountActive by the number of placed bricks
    public void PlaceBricks(List<Vector2> positions, List<Sprite> images)
    {
        print("placing level bricks");
        for (int i = 0; i < positions.Count; ++i)
        {
            objectToPlace = GetPooledObject();
            objectToPlace.SetBrick(positions[i], images[i]);
            amountActive++;
        }

    }
}
