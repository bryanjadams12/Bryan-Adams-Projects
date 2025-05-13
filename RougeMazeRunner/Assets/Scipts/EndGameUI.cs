using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    public GameObject winUI;
    public GameObject loseUI;

    public void ShowWin()
    {
        if (winUI != null)
            winUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowLose()
    {
        if (loseUI != null)
            loseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0); // Assumes main menu is scene 0
    }
}