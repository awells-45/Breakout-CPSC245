using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public ObjectPool objectPool;
    public int numberInLevel;
    public List<Transform> brickPositions;
    public List<Sprite> brickImages;

    private void Awake()
    {
        objectPool = FindObjectOfType<ObjectPool>();
        objectPool.amountToPool = numberInLevel;
    }

    public void OnButtonClick()
    {
        //objectPool.PlaceBricks(brickPositions, brickImages);
    }
}
