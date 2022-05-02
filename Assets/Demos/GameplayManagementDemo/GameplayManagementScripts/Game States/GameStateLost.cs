public class GameStateLost : GameState
{
    // Delegate for the events below
    public delegate void BeginLoseState();
    
    // Event that is broadcast when the Lose state is entered
    public static event BeginLoseState LoseStateBegin;
    // Event that is broadcast when the LoadLevel state is exited
    public static event BeginLoseState LoseStateEnd;
    
    // Called when the state is entered in GameManager
    public override void OnStateEntered()
    {
        // Check to make sure something is subscribed to the event before being called
        if (LoseStateBegin != null)
        {
            // Behavior dependent on lost state entering will subscribe to this broadcast
            LoseStateBegin();
        }
    }
    
    // Called when the state is exited in GameManager
    public override void OnStateExited()
    {
        // Check to make sure something is subscribed to the event before being called
        if (LoseStateEnd != null) {
            // Behavior dependent on lost state exiting will subscribe to this broadcast
            LoseStateEnd();
        }
    }
}