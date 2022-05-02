using UnityEngine;

public class TestButtons : MonoBehaviour
{
    //Events mimicking the GameState GameStateEnter and GameStateExit methods on each GameState class
    public delegate void PublishState();

    public static event PublishState MainMenuStart;
    public static event PublishState MainMenuEnd;
    public static event PublishState PauseMenuStart;
    public static event PublishState PauseMenuEnd;
    public static event PublishState WinScreenStart;
    public static event PublishState WinScreenEnd;
    public static event PublishState LoseScreenStart;
    public static event PublishState LoseScreenEnd;
    
    //All the methods mimic the OnStateEnter() and OnStateExit() methods that invoke the events in each GameState class
    public void OnClickPlay()  //Play screen is the layer under all the canvas group
        //To play just hide the main menu
    {
        if (MainMenuEnd != null)
        {
            MainMenuEnd();
        }
    }
    
    public void OnClickPause()
    {
        if (PauseMenuStart != null)
        {
            PauseMenuStart();
        }
    }

    public void OnClickResume()
    {
        if (PauseMenuEnd != null)
        {
            PauseMenuEnd();
        }
    }
    
    public void OnClickMainMenu()
    {
        if (MainMenuStart != null)
        {
            MainMenuStart();
        }
    }

    public void OnClickReturn()
    {
        if (MainMenuStart != null && LoseScreenEnd != null && WinScreenEnd != null && PauseMenuEnd != null)
        {
            LoseScreenEnd();
            WinScreenEnd();
            PauseMenuEnd();
            MainMenuStart();
        }
    }
    
    public void OnClickLose()
    {
        if (LoseScreenStart != null)
        {
            LoseScreenStart();
        }
    }
    
    public void OnClickWin()
    {
        if (WinScreenStart != null)
        {
           WinScreenStart();
        }
    }
}
