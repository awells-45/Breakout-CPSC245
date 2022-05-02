using UnityEngine;
using UnityEngine.UI;

public abstract class GameState {


    public abstract void OnStateEntered();

    public abstract void OnStateExited();
}