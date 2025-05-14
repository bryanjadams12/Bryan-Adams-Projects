using UnityEngine;

public class InGameAudioToggle : MonoBehaviour
{
    [SerializeField] private GameObject volumeOnButton;
    [SerializeField] private GameObject volumeOffButton;

    private AudioSource gameMusicSource;
    private bool isMuted = false;

    void Start()
    {
        // Get reference to game music source from GameManager
        if (GameManager.Instance != null)
        {
            gameMusicSource = GameManager.Instance.gameMusicSource;
        }

        if (gameMusicSource == null)
        {
            Debug.LogWarning("InGameAudioToggle: No music source found from GameManager!");
        }

        UpdateUI();
    }

    public void ToggleGameMusic()
    {
        isMuted = !isMuted;

        if (gameMusicSource != null)
        {
            gameMusicSource.mute = isMuted;
            Debug.Log("In-game music is now " + (isMuted ? "muted" : "unmuted"));
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (volumeOnButton != null) volumeOnButton.SetActive(!isMuted);
        if (volumeOffButton != null) volumeOffButton.SetActive(isMuted);
    }
}