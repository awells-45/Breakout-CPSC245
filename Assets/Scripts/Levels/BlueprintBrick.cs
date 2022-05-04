/* a. Ian Reafsnyder, Lucas Torti, and Natalie Huante
 * b. 2337621, 2351555, 2374481
 * c. ireafsnyder@chapman.edu, torti@chapman.edu, huante@chapman.edu
 * d. CPSC 245-01
 * e. Brick buster class project
 *
 * A serializable object used in levels
 * Its only purpose is to store data for later use. It stores data for a brick to be created by the LevelLoadManager
 */

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

    // Returns a Vector2 representation of the brick's location
    public Vector2 GetTransform()
    {
        Vector2 newVector = new Vector2(brickTransform.x, brickTransform.y);
        return newVector;
    }
    
    // Accessor for brickSprite
    public Sprite GetSprite()
    {
        return brickSprite;
    }

}