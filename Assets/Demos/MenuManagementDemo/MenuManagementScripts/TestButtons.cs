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
    public void OnClickPlay()  
    {
        // Play screen is the base layer under all the other canvas groups
        // To play just hide the main menu
        if (MainMenuEnd != null)
        {
            MainMenuEnd();
        }
    }
    
    // Invokes PauseMenuStart event and shows the pause menu canvas group
    public void OnClickPause()
    {
        if (PauseMenuStart != null)
        {
            PauseMenuStart();
        }
    }

    // Invokes PauseMenuEnd event and hides the pause menu canvas group
    public void OnClickResume()
    {
        if (PauseMenuEnd != null)
        {
            PauseMenuEnd();
        }
    }
    
    // Invokes MainMenuStart event and hides the main menu canvas group
    public void OnClickMainMenu()
    {
        if (MainMenuStart != null)
        {
            MainMenuStart();
        }
    }

    // Invokes MainMenuEnd event, shows the main menu canvas group
    // Invokes end events for any screen that may already be up upon clicking a MainMenu button
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
    
    // Invokes LoseScreenStart event and shows the lose screen canvas group
    public void OnClickLose()
    {
        if (LoseScreenStart != null)
        {
            LoseScreenStart();
        }
    }
    
    // Invokes WinScreenStart event and shows the win screen canvas group
    public void OnClickWin()
    {
        if (WinScreenStart != null)
        {
           WinScreenStart();
        }
    }
}
