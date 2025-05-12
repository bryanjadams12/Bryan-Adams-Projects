using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }


    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1; // Resume the game
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1; // Resume the game
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1; // Resume the game
    }
    public void Sound()
    {
        // Implement sound settings here to mute or unmute the game
        Time.timeScale = 1; // Resume the game

    }
        public void Settings()
    {
        // Implement settings here to mute or unmute the game
        Time.timeScale = 1; // Resume the game

    }

}
