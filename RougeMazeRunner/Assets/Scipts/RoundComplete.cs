using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RoundCompleteUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI roundText;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button homeButton;

    private void Start()
    {
        panel.SetActive(false);

        nextButton.onClick.AddListener(OnNextRound);
        restartButton.onClick.AddListener(OnRestart);
        homeButton.onClick.AddListener(OnHome);
    }

    public void Show(int roundNumber)
    {
        roundText.text = $"Round {roundNumber} Completed!";
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnNextRound()
    {
        Time.timeScale = 1f;

        // Re-enable movement and start the next round
        if (GameManager.Instance != null)
        {
            GameManager.Instance.playerMovement.SetMovementEnabled(true);
            GameManager.Instance.StartRound();
        }

        panel.SetActive(false); // Hide only the round complete panel
    }

    private void OnRestart()
    {
        Time.timeScale = 1f;
        GameManager.Instance.RestartGame(); // This should reset the round and restart
    }

    private void OnHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}