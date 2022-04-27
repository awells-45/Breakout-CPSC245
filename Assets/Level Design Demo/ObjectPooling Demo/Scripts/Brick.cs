using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject brick;
    public LevelLoadManager levelLoadManager;
    public Sprite image; // brick art image
    private SpriteRenderer spriteRenderer;
    private ObjectPool objectPool;

    private void Awake()
    {
        brick = this.gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelLoadManager = FindObjectOfType<LevelLoadManager>();
        objectPool = FindObjectOfType<ObjectPool>();
    }

    // called when the brick is hit by the ball
    public void OnHit()
    {
        // set the brick to inactive
        HideBrick();
        //levelLoadManager.DecrementActiveBricks();
        objectPool.amountActive--;
    }
    
    // sets the brick to active in the scene
    public void ShowBrick()
    {
        brick.SetActive(true);
    }
    
    // sets the brick to inactive in the scene
    private void HideBrick()
    {
        brick.SetActive(false);
    }

    // sets up the brick for the level given position and sprite
    public void SetBrick(Transform location, Sprite newImage)
    {
        SetBrickLocation(location);
        SetBrickSprite(newImage);
    }
    
    // places the brick to its correct position in the level given the transform position
    private void SetBrickLocation(Transform location)
    {
        gameObject.transform.position = location.position;
        ShowBrick();
    }

    // assigns the brick's sprite
    private void SetBrickSprite(Sprite newImage)
    {
        image = newImage;
        spriteRenderer.sprite = image;
    }
    
}
