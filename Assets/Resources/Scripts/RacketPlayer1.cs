using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer1 : MonoBehaviour
{
    public float movementSpeed;

    private void FixedUpdate()
    {
        // Apply keyboard input to racket
        float v = Input.GetAxisRaw("Player1Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
    }
}
