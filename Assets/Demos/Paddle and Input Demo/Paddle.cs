using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public int leftBound;
    public int rightBound;

    public void OnLeftPress() {
        //if (gameState == alive)
        if (true)
        {
            if (this.transform.position.x > leftBound) 
                this.transform.position += Vector3.left * 0.1f;
        }
    }

    public void OnRightPress() {
        //if (gameState == alive) 
        if (true)
        {
            if (this.transform.position.x < rightBound)
                this.transform.position += Vector3.right * 0.1f;
        }
    }

    public void OnGameReset() { // This needs to be triggered by an event
        //this.transform.position.x = 0;
    }
}
