public class GameStateWon : GameState
{
    // Delegate for the events below
    public delegate void WonStateEvent();

    // Event that is broadcast when the Won state is entered
    public static event WonStateEvent WonStateBegin;
    // Event that is broadcast when the Won state is exited
    public static event WonStateEvent WonStateEnd;

    // Called when the state is entered in GameManager
    public override void OnStateEntered()
    {
        // Check to make sure something is subscribed to the event before being called
        if (WonStateBegin != null)
        {
            // Behavior dependent on Won state entering will subscribe to this broadcast
            WonStateBegin();
        }
    }
    
    // Called when the state is exited in GameManager
    public override void OnStateExited()
    {
        // Check to make sure something is subscribed to the event before being called
        if (WonStateEnd != null) {
            // Behavior dependent on Playing state exiting will subscribe to this broadcast
            WonStateEnd();
        }
    }
}