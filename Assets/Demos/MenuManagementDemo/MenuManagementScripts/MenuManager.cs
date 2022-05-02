using UnityEngine;

public class MenuManager : MonoBehaviour
{
	//private bool isPaused = false;
	[SerializeField] private CanvasGroup mainMenuGroup;
	[SerializeField] private CanvasGroup pauseMenuGroup;
	[SerializeField] private CanvasGroup loseScreenGroup;
	[SerializeField] private CanvasGroup winScreenGroup;

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
    
	//Input that I'm not sure which script is handling
	// private void Update() { 
	// 	if (Input.GetKeyDown(KeyCode.Escape)) {
	// 		isPaused = !isPaused;
	// 		if(isPaused)
	// 		{ 
	// 			gameManager.ChangeToNewState(GameStatePaused);
	// 		}
	// 		else
	// 		{ 
	// 			gameManager.ChangeToNewState(GameStatePlaying);
	// 		}
	// 	}
	// }
    
	// public void OnPauseButtonClick()
	// {
	// 	isPaused = !isPaused;
	// 	if(isPaused)
	// 	{ 
	// 		gameManager.ChangeToNewState(GameStatePaused);
	// 	}
	// 	else
	// 	{ 
	// 		gameManager.ChangeToNewState(GameStatePlaying);
	// 	}
	// }
    
	// public void OnMainMenuButtonClick()
	// {
	// 	gameManager.ChangeToNewState(GameStateMainMenu);
	// }
	// public void OnPlayButtonClick()
	// {
	// 	gameManager.ChangeToNewState(GameStatePlaying);
	// }
        
	public void OnQuitButtonClick()
	{
		Application.Quit();
	}

	private void ShowMainMenu()
	{
		Show(mainMenuGroup);
	}

	private void HideMainMenu()
	{
		Hide(mainMenuGroup);
	}
	
	private void ShowPauseMenu()
	{
		Show(pauseMenuGroup);
	}

	private void HidePauseMenu()
	{
		Hide(pauseMenuGroup);
	}
	
	private void ShowLoseScreen()
	{
		Show(loseScreenGroup);
	}

	private void HideLoseScreen()
	{
		Hide(loseScreenGroup);
	}
	
	private void ShowWinScreen()
	{
		Show(winScreenGroup);
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
	
	//Showing the screen and enabling interaction
	private void Show(CanvasGroup group)
	{
		group.alpha = 1;
		group.interactable = true;
		group.blocksRaycasts = true;
	}

}
