/* a. Ian Reafsnyder, Lucas Torti, and Natalie Huante
 * b. 2337621, 2351555, 2374481
 * c. ireafsnyder@chapman.edu, torti@chapman.edu, huante@chapman.edu
 * d. CPSC 245-01
 * e. Brick buster class project
 *
 * Contains all methods and data relevant to an individual brick
 */

//Created by Natalie Huante
//Overall purpose: Manages all actions and data of an individual brick

using UnityEngine;

public class Brick : MonoBehaviour
{
    public LevelLoadManager levelLoadManager;
    public Sprite image; // brick art image
    private SpriteRenderer spriteRenderer;
    private ObjectPool objectPool;

    // assigns objects when the brick is created by the object pool 
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelLoadManager = FindObjectOfType<LevelLoadManager>();
        objectPool = FindObjectOfType<ObjectPool>();
    }

    // when brick is collided with by ball, brick is set to inactive and the number of active bricks is updated
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball")) // if the collision is with the ball
        {
            // set the brick to inactive
            HideBrick();
            
            // update the number of active bricks
            //levelLoadManager.DecrementActiveBricks();
            objectPool.amountActive--;
        }
    }

    // sets the brick to active in the scene
    public void ShowBrick()
    {
        gameObject.SetActive(true);
    }
    
    // sets the brick to inactive in the scene
    private void HideBrick()
    {
        gameObject.SetActive(false);
    }

    // sets up the brick for the level given position and sprite
    public void SetBrick(Vector2 location, Sprite newImage)
    {
        SetBrickLocation(location);
        SetBrickSprite(newImage);
    }
    
    // places the brick to its correct position in the level given the transform position
    private void SetBrickLocation(Vector2 location)
    {
        gameObject.transform.position = location;
        ShowBrick();
    }

    // assigns the brick's sprite
    private void SetBrickSprite(Sprite newImage)
    {
        image = newImage;
        spriteRenderer.sprite = image;
    }
    
}
