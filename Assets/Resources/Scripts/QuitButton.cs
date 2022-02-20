using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void EndGame() {
        Debug.Log("Quit game was called.");

        // Move us to the Game scene
        Application.Quit();
    }
}
