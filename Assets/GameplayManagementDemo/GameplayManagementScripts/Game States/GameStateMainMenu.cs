public class GameStateMainMenu : GameState
{
    public delegate void MainMenuEvent();
    public static event MainMenuEvent MainMenuStateBegin;
    public static event MainMenuEvent MainMenuStateEnd;

    public override void OnStateEntered()
    {
        if (MainMenuStateBegin != null)
        {
            // things will subscribe to this event that need to handle loss stuff
            MainMenuStateBegin();
        }
    }
    
    public override void OnStateExited()
    {
        if (MainMenuStateEnd != null)
        {
            // things will subscribe to this event that need to handle loss stuff
            MainMenuStateEnd();
        }
    }
}