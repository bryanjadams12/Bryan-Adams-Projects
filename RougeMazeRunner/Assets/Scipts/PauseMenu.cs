using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private bool isMuted = false;

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
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;
        Debug.Log("Sound toggled. Muted: " + isMuted);

        // Do NOT resume the game
        // Time.timeScale stays unchanged
    }

    
}
