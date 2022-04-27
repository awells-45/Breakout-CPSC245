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
            print("made brick: " + (i+1));
        }
    }

    public void Reset()
    {
        // resets all bricks to inactive
        for (int i = 0; i < amountToPool; ++i)
        {
            pooledBricks[i].gameObject.SetActive(false);
        }

        amountActive = 0;
    }

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
