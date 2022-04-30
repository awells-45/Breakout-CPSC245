public class GameStateWon : GameState
{
    public delegate void WonStateEvent();

    public static event WonStateEvent WonStateBegin;
    public static event WonStateEvent WonStateEnd;

    public override void OnStateEntered()
    {
        if (WonStateBegin != null)
        {
            // things will subscribe to this event that need to handle loss stuff
            WonStateBegin();
        }
    }
    
    public override void OnStateExited()
    {
        if (WonStateEnd != null) {
            WonStateEnd();
        }
    }
}