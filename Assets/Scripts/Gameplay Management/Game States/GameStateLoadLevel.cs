public class GameStateLoadLevel : GameState
{
    // Delegate for the events below
    public delegate void LoadLevelStateEvent();

    // Event that is broadcast when the LoadLevel state is entered
    public static event LoadLevelStateEvent LoadLevelStateBegin;
    // Event that is broadcast when the LoadLevel state is exited
    public static event LoadLevelStateEvent LoadLevelStateEnd;

    // Called when the state is entered in GameManager
    public override void OnStateEntered()
    {
        // Check to make sure something is subscribed to the event before being called
        if (LoadLevelStateBegin != null)
        {
            // Behavior dependent on load level state entering will subscribe to this broadcast
            LoadLevelStateBegin();
        }
    }
    
    // Called when the state is exited in GameManager
    public override void OnStateExited()
    {
        // Check to make sure something is subscribed to the event before being called
        if (LoadLevelStateEnd != null) {
            // Behavior dependent on load level state exiting will subscribe to this broadcast
            LoadLevelStateEnd();
        }
    }
}