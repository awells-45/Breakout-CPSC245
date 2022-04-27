using UnityEngine;

public class Paddle : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject rightWall;
    //public GameManager gameManager;

    public void OnLeftPress() {
        //if (gameManager.getState() == alive)???
        if (true)
        {
            var paddleLeftEdge = this.transform.position.x - (this.GetComponent<Collider2D>().bounds.size.x / 2);
            var wallRightEdge = leftWall.transform.position.x + (leftWall.GetComponent<Collider2D>().bounds.size.x / 2);
            if (paddleLeftEdge > wallRightEdge) 
                this.transform.position += Vector3.left * 0.1f;
        }
    }

    public void OnRightPress() {
        //if (gameManager.getState() == alive)??? 
        if (true)
        {
            var paddleRightEdge = this.transform.position.x + (this.GetComponent<Collider2D>().bounds.size.x / 2);
            var wallLeftEdge = rightWall.transform.position.x - (rightWall.GetComponent<Collider2D>().bounds.size.x / 2);
            if (paddleRightEdge < wallLeftEdge)
                this.transform.position += Vector3.right * 0.1f;
        }
    }

    public void OnGameReset() { // This needs to be triggered by an event
        //this.transform.position.x = 0;
    }
}
