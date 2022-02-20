using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maximumSpeed;

    int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        // This limits how often this StartBall is called
        StartCoroutine(this.StartBall());
    }

    void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (isStartingPlayer1 == true)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        } else {
            this.gameObject.transform.localPosition = new Vector3( 100, 0, 0);
        }
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);

        this.hitCounter = 0;
        // Wait 2 seconds before the game starts
        yield return new WaitForSeconds(2);
        // Set the direction towards the racket
        if (isStartingPlayer1 == true)
        {
            this.MoveBall(new Vector2(-1, 0));
        } else {
            this.MoveBall(new Vector2( 1, 0));
        }
    }

    public void MoveBall(Vector2 dir)
    {
        // Define the ball speed
        dir = dir.normalized;
        float speed = this.movementSpeed + (this.hitCounter * this.extraSpeedPerHit);

        // Apply the ball speed to the ball
        Rigidbody2D rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = dir * speed;
    }

    public void IncreaseHitCounter()
    {
        // We need to limit the ball speed so it doesn't get out of control
        if (this.hitCounter * this.extraSpeedPerHit < this.maximumSpeed)
        {
            this.hitCounter++;
        }
    }
}
