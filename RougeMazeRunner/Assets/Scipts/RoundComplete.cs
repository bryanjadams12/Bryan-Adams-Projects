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

    private void OnNextRound()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        GameManager.Instance.StartNextRound();
    }

    private void OnRestart()
    {
        Time.timeScale = 1f;
        GameManager.Instance.RestartGame(); // Call a function to reset game state and start from round 1
    }

    private void OnHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
