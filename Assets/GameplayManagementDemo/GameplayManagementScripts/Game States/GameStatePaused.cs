public class GameStatePaused : GameState
{
    public delegate void PauseStateEvent();
    public static event PauseStateEvent PauseStateBegin;
    public static event PauseStateEvent PauseStateEnd;
    

    public override void OnStateEntered()
    {
        if (PauseStateBegin != null)
        {
            // things will subscribe to this event that need to handle loss stuff
            PauseStateBegin();
        }
    }
    
    public override void OnStateExited()
    {
        if (PauseStateEnd != null) {
            PauseStateEnd();
        }
    }
}