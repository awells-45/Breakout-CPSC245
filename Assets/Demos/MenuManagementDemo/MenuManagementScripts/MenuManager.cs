using UnityEngine;

public class MenuManager : MonoBehaviour
{
	//private bool isPaused = false;
	[SerializeField] private CanvasGroup mainMenuGroup;
	[SerializeField] private CanvasGroup pauseMenuGroup;
	[SerializeField] private CanvasGroup loseScreenGroup;
	[SerializeField] private CanvasGroup winScreenGroup;
	[SerializeField] private CanvasGroup playingScreenGroup;

	private void OnEnable()
    {
	    //Actual GameState Events MenuManager should subscribe to
	    // GameStateWon.WonStateBegin += ShowWinScreen;
	    // GameStateWon.WonStateEnd += HideWinScreen;
	    // GameStateLost.LoseStateBegin += ShowLoseScreen;
	    // GameStateWon.WonStateEnd += HideLoseScreen;
	    // GameStatePaused.PauseStateBegin += ShowPauseMenu;
	    // GameStatePaused.PauseStateEnd += HidePauseMenu;
	    // GameStateMainMenu.MainMenuStateBegin += ShowMainMenu;
	    // GameStateMainMenu.MainMenuStateEnd += HideMainMenu;
	    
	    //subscribing the Show and Pause methods to the test events on TestButtons
	    TestButtons.PauseMenuStart += ShowPauseMenu;
	    TestButtons.PauseMenuEnd += HidePauseMenu;
	    TestButtons.MainMenuStart += ShowMainMenu;
	    TestButtons.MainMenuEnd += HideMainMenu;
	    TestButtons.WinScreenStart += ShowWinScreen;
	    TestButtons.WinScreenEnd += HideWinScreen;
	    TestButtons.LoseScreenStart += ShowLoseScreen;
	    TestButtons.LoseScreenEnd += HideLoseScreen;
    }
	
	public void OnQuitButtonClick()
	{
		Application.Quit();
	}

	private void ShowMainMenu()
	{
		Show(mainMenuGroup);
		Hide(playingScreenGroup);
	}

	private void HideMainMenu()
	{
		Hide(mainMenuGroup);
		Show(playingScreenGroup);
	}
	
	private void ShowPauseMenu()
	{
		Show(pauseMenuGroup);
		BlockInteraction(playingScreenGroup);
	}

	private void HidePauseMenu()
	{
		Hide(pauseMenuGroup);
		AllowInteraction(playingScreenGroup);
	}
	
	private void ShowLoseScreen()
	{
		Show(loseScreenGroup);
		Hide(playingScreenGroup);
	}

	private void HideLoseScreen()
	{
		Hide(loseScreenGroup);
	}
	
	private void ShowWinScreen()
	{
		Show(winScreenGroup);
		Hide(playingScreenGroup);
	}
	
	private void HideWinScreen()
	{
		Hide(winScreenGroup);
	}
	
	//Hiding the screen invisible and disabling interaction
	private void Hide(CanvasGroup group)
	{
		group.alpha = 0; 
		group.interactable = false; 
		group.blocksRaycasts = false;
	}

	private void BlockInteraction(CanvasGroup group)
	{
		group.interactable = false;
		group.blocksRaycasts = false;
	}
	
	private void AllowInteraction(CanvasGroup group)
	{
		group.interactable = true;
		group.blocksRaycasts = true;
	}
	
	//Showing the screen and enabling interaction
	private void Show(CanvasGroup group)
	{
		group.alpha = 1;
		group.interactable = true;
		group.blocksRaycasts = true;
	}

}
