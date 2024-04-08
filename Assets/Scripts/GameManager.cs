using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameHasEnded = false;

    public float RestartDelay = 1f; // Making a variable

    public void EndGame() //Creating a function called Endgame and making it public to call it in other scripts.
    {
        if (GameHasEnded == false)
        {
            GameHasEnded = true;
            Debug.Log("GAME OVER!"); //Printing Game Over in the console.
            // Restart Game
            Invoke("Restart", RestartDelay); // This is used to call the restart function after some delay and that delay value is stored in RestartDelay variable.
        }

    }

    void Restart() // Creating a function called Restart.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Now this line of code loads the current active scene.
    }

}
