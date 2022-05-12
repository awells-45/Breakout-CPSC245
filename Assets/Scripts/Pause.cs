using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public PlayerInputActions playerInputs;
    public GameManager gameManager;

    public delegate void EnterPauseState(State pauseState);

    public static event EnterPauseState OnPause;
    
    private bool isPaused = false;

    private void Awake()
    {
        playerInputs = new PlayerInputActions();
    }
    
    private void OnEnable()
    {
        playerInputs.Player.Pause.performed += PauseGame;
        playerInputs.Player.Pause.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Player.Pause.performed -= PauseGame;
        playerInputs.Player.Pause.Disable();
    }

    public void PauseGame(InputAction.CallbackContext callback)
    {
        if (gameManager.IsMainMenu())
        {
            return;
        }
        
        if (isPaused)
        {
            if (OnPause != null)
            {
                OnPause(State.Playing);
            }
            
        }
        else
        {
            if (OnPause != null)
            {
                OnPause(State.Pause);
            }
        }
        
        isPaused = !isPaused;
        
        return;
    }
}
