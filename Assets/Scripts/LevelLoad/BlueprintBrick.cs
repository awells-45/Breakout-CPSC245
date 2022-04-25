using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class BlueprintBrick
{
    public Vector2 brickTransform;
    public Color color;

    public Vector2 GetTransform()
    {
        Vector2 newVector = new Vector2(brickTransform.x, brickTransform.y);
        return newVector;
    }

    public Color GetColor()
    {
        return color;
    }

}