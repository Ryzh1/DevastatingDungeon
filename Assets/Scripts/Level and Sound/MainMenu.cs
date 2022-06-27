using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // When the play button is pressed load scene 1.
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(GameObject.FindWithTag("Enemy"));
        Destroy(GameObject.FindWithTag("PowerUp"));

    }

    // When the exit button is pressed close the game.
    public void Exit()
    {
        Application.Quit();
    }




}
