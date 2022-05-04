public class GameStateMainMenu : GameState
{
    // Delegate for the events below
    public delegate void MainMenuEvent();
    
    // Event that is broadcast when the MainMenu state is entered
    public static event MainMenuEvent MainMenuStateBegin;
    // Event that is broadcast when the MainMenu state is exited
    public static event MainMenuEvent MainMenuStateEnd;

    // Called when the state is entered in GameManager
    public override void OnStateEntered()
    {
        // Check to make sure something is subscribed to the event before being called
        if (MainMenuStateBegin != null)
        {
            // Behavior dependent on MainMenu state entering will subscribe to this broadcast
            MainMenuStateBegin();
        }
    }
    
    // Called when the state is exited in GameManager
    public override void OnStateExited()
    {
        // Check to make sure something is subscribed to the event before being called
        if (MainMenuStateEnd != null)
        {
            // Behavior dependent on MainMenu state exiting will subscribe to this broadcast
            MainMenuStateEnd();
        }
    }
}