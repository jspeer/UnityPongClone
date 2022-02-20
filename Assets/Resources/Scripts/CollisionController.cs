using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreController scoreController;

    void BounceFromRacket(Collision2D c)
    {
        // Get the object positions
        Vector3 ballPosition = this.transform.position;
        Vector3 racketPosition = c.transform.position;

        // Calculate the direction of the bounce
        float racketHeight = c.collider.bounds.size.y;
        float x;
        // If player 1, we want forward direction, else we want reverse direction
        x = (c.gameObject.name == "RacketPlayer1") ? 1 : -1;
        // This causes the angle to change based on where on the racket the ball impacts
        float y = (ballPosition.y - racketPosition.y) / racketHeight;

        // Increase ball speed and apply direction
        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.name == "RacketPlayer1" || c.gameObject.name == "RacketPlayer2")
        {
            this.BounceFromRacket(c);
        } else if (c.gameObject.name == "WallLeft") {
            Debug.Log("Collision with WallLeft");
            this.scoreController.GoalPlayer2();
            StartCoroutine(this.ballMovement.StartBall(true));
        } else if (c.gameObject.name == "WallRight") {
            Debug.Log("Collision with WallRight");
            this.scoreController.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }
}

