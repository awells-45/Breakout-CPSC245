using UnityEngine;

public class Paddle : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject rightWall;
    public float moveAmount;

    private bool _gameIsPlaying = false;

    public void OnLeftPress() {
        if(_gameIsPlaying)
        {
            var paddleLeftEdge = this.transform.position.x - (this.GetComponent<Collider2D>().bounds.size.x / 2);
            var wallRightEdge = leftWall.transform.position.x + (leftWall.GetComponent<Collider2D>().bounds.size.x / 2);
            if (paddleLeftEdge > wallRightEdge) 
                this.transform.position += Vector3.left * moveAmount;
        }
    }

    public void OnRightPress() {
        if (_gameIsPlaying)
        {
            var paddleRightEdge = this.transform.position.x + (this.GetComponent<Collider2D>().bounds.size.x / 2);
            var wallLeftEdge = rightWall.transform.position.x - (rightWall.GetComponent<Collider2D>().bounds.size.x / 2);
            if (paddleRightEdge < wallLeftEdge)
                this.transform.position += Vector3.right * moveAmount;
        }
    }

    public void StartGame() // Triggered by EnterPlayingState or the Ball's LaunchingBall event
    {
        _gameIsPlaying = true;
    }

    public void PauseGame()  // Triggered by EnterPauseState
    {
        _gameIsPlaying = false;
    }
    
    public void StopGame() { // Triggered by EnterMainMenuState or EnterWonState or EnterLostState or the Ball's LostLife event
        _gameIsPlaying = false;
        ResetPaddle();
    }

    public void ResetPaddle() {
        this.transform.position = new Vector3(0, -2.4f, 0);
    }
}
