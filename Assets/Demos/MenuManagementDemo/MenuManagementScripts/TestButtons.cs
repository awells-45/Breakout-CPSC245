using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtons : MonoBehaviour
{

    public delegate void PublishState();

    public static event PublishState MainMenu;
    public static event PublishState PauseMenu;
    public static event PublishState PlayScreen;
    public static event PublishState WinScreen;
    public static event PublishState LoseScreen;

    public void OnClick(PublishState newState)
    {
        if (newState != null)
        {
            newState();
        }
    }
}
