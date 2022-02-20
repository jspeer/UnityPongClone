using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame() {
        Debug.Log("Play Game was pressed. Moving to Game scene.");

        // Move us to the Game scene
        SceneManager.LoadScene(1);
    }
}
