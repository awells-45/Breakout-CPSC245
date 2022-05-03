using UnityEngine;
using UnityEngine.UI;

public abstract class GameState {
    // Method that is overriden by each game state when the game state is entered
    public abstract void OnStateEntered();
    // Method that is overriden by each game state when the game state is exited
    public abstract void OnStateExited();
}