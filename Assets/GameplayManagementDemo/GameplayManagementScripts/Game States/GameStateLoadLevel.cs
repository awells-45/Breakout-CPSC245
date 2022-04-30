public class GameStateLoadLevel : GameState
{
    public delegate void LoadLevelStateEvent();

    public static event LoadLevelStateEvent LoadLevelStateBegin;
    public static event LoadLevelStateEvent LoadLevelStateEnd;

    public override void OnStateEntered()
    {
        if (LoadLevelStateBegin != null)
        {
            // things will subscribe to this event that need to handle loss stuff
            LoadLevelStateBegin();
        }
    }
    
    public override void OnStateExited()
    {
        if (LoadLevelStateEnd != null) {
            LoadLevelStateEnd();
        }
    }
}