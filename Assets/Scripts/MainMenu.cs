using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene (make sure the scene is added in Build Settings)
        SceneManager.LoadScene("Slideshow"); // Replace "GameScene" with the name of your game scene
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Button Clicked");
    }
}
