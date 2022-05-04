using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void KillBallEvent();

public class Killzone : MonoBehaviour
{
    public static event KillBallEvent KillBallCollision;

    private void OnCollisionEnter2D(Collision2D collision) // ball hits kill zone
    {
        if (KillBallCollision != null)
        {
            KillBallCollision();  // kill event - Ball should be killed; a life should be lost; paddle should be reset
        }
    }
}
