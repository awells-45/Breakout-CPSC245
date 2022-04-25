using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject rightWall;
    //public GameManager gameManager;

    public void OnLeftPress() {
        //if (gameManager.getState() == alive)???
        if (true)
        {
            if (this.transform.position.x > leftWall.transform.position.x) 
                this.transform.position += Vector3.left * 0.1f;
        }
    }

    public void OnRightPress() {
        //if (gameManager.getState() == alive)??? 
        if (true)
        {
            if (this.transform.position.x < rightWall.transform.position.x)
                this.transform.position += Vector3.right * 0.1f;
        }
    }

    public void OnGameReset() { // This needs to be triggered by an event
        //this.transform.position.x = 0;
    }
}
