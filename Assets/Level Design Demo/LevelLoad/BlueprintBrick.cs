//Created by Ian Reafsnyder and Lucas Torti
//Overall purpose: Create a serializable object which is used in levels.
//To simplify: Its only purpose is to store data for later use. It specifically stores data for a brick.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class BlueprintBrick
{
    //The brick's location
    public Vector2 brickTransform;
    //Brick's sprite
    public Sprite brickSprite;

    public Vector2 GetTransform()
    {
        Vector2 newVector = new Vector2(brickTransform.x, brickTransform.y);
        return newVector;
    }

    public Sprite GetSprite()
    {
        return brickSprite;
    }

}