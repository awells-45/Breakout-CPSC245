public class GameStatePlaying : GameState
{
    public delegate void PlayingStateEvent();

    public static event PlayingStateEvent PlayingStateBegin;
    public static event PlayingStateEvent PlayingStateEnd;

    public override void OnStateEntered()
    {
        if (PlayingStateBegin != null)
        {
            // things will subscribe to this event that need to handle loss stuff
            PlayingStateBegin();
        }
    }
    
    public override void OnStateExited()
    {
        if (PlayingStateEnd != null) {
            PlayingStateEnd();
        }
    }
}