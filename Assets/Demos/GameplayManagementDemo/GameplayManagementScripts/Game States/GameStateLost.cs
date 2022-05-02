public class GameStateLost : GameState
{
    public delegate void BeginLoseState();
    
    public static event BeginLoseState LoseStateBegin;
    public static event BeginLoseState LoseStateEnd;

    public override void OnStateEntered()
    {
        if (LoseStateBegin != null)
        {
            // things will subscribe to this event that need to handle loss stuff
            LoseStateBegin();
        }
    }
    
    public override void OnStateExited()
    {
        if (LoseStateEnd != null) {
            LoseStateEnd();
        }
    }
}