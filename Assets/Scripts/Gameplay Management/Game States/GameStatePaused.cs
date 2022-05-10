using UnityEngine;

public class GameStatePaused : GameState
{
    // Delegate for the events below
    public delegate void PauseStateEvent();

    // Event that is broadcast when the Paused state is entered
    public static event PauseStateEvent PauseStateBegin;
    // Event that is broadcast when the Paused state is exited
    public static event PauseStateEvent PauseStateEnd;

    // Called when the state is entered in GameManager
    public override void OnStateEntered()
    {
        // Check to make sure something is subscribed to the event before being called
        if (PauseStateBegin != null)
        {
            // Behavior dependent on Paused state entering will subscribe to this broadcast
            PauseStateBegin();
        }
    }

    // Called when the state is exited in GameManager
    public override void OnStateExited()
    {
        // Check to make sure something is subscribed to the event before being called
        if (PauseStateEnd != null)
        {
            // Behavior dependent on Paused state exiting will subscribe to this broadcast
            PauseStateEnd();
        }
    }
}