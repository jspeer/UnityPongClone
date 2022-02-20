using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource racketSound;

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.name == "RacketPlayer1" || c.gameObject.name == "RacketPlayer2")
        {
            this.racketSound.Play();
        } else {
            this.wallSound.Play();
        }
    }
}
