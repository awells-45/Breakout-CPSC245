using UnityEditor.U2D;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	private bool isPaused = false;
    private void OnEnable()
    {
	    // GameStateWon.WonStateBegin += ShowWinScreen();
	    // GameStateWon.WonStateEnd += HideWinScreen();
	    // GameStateLost.LoseStateBegin += ShowLoseScreen();
	    // GameStateWon.WonStateEnd += HideLoseScreen();
	    //TestButtons.MainMenu += 
    }
    
	private void Update() { 
		if (Input.GetKeyDown(KeyCode.Escape)) {
			isPaused = !isPaused;
			if(isPaused)
			{ 
				//GameStatePaused.PauseStateBegin += ShowPauseMenu();
			}
			else
			{ 
				//GameStatePaused.PauseStateEnd += HidePauseMenu();
			}
		}
	}
    
    	public void OnPauseButtonClick()
        {
	        isPaused = !isPaused;
	        if(isPaused)
	        { 
		        //GameStatePaused.PauseStateBegin += ShowPauseMenu();
	        }
	        else
	        { 
		        //GameStatePaused.PauseStateEnd += HidePauseMenu();
	        }
        }
    
    	public void OnMainMenuButtonClick()
        {
	        //GameStateMainMenu.MainMenuStateBegin += ShowMainMenu();
        }
    	public void OnPlayButtonClick()
        {
	        //GameStatePlaying.PlayingStateBegin += ShowPlayScreen();
        }
        
    	public void OnQuitButtonClick()
        {
	        Application.Quit();
        }

}
