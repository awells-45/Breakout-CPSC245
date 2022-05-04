public class GameStatePlaying : GameState
{
    // Delegate for the events below
    public delegate void PlayingStateEvent();

    // Event that is broadcast when the Playing state is entered
    public static event PlayingStateEvent PlayingStateBegin;
    // Event that is broadcast when the Playing state is exited
    public static event PlayingStateEvent PlayingStateEnd;

    // Called when the state is entered in GameManager
    public override void OnStateEntered()
    {
        // Check to make sure something is subscribed to the event before being called
        if (PlayingStateBegin != null)
        {
            // Behavior dependent on Playing state entering will subscribe to this broadcast
            PlayingStateBegin();
        }
    }
    
    // Called when the state is exited in GameManager
    public override void OnStateExited()
    {
        // Check to make sure something is subscribed to the event before being called
        if (PlayingStateEnd != null) {
            // Behavior dependent on Playing state exiting will subscribe to this broadcast
            PlayingStateEnd();
        }
    }
}