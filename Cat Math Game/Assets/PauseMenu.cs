using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for changing scenes

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        // Assuming your main menu scene is named "MainMenu"
        // Change "MainMenu" to the actual name of your menu scene
        SceneManager.LoadScene(0);
        Time.timeScale = 1f; // Ensure game time is resumed
    }

    public void QuitGame()
    {
        // Logs to console when running in the Unity editor
        Debug.Log("Quitting game...");

        // Quits the application
        Application.Quit();
    }
}
