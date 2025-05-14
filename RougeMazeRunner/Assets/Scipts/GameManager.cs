using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalRounds = 3;
    public int currentRound = 1;
    [Header("Round Settings")]
    public float[] roundTimeLimits = new float[] { 60f, 45f, 30f }; // Round 1 → 60s, Round 2 → 45s, Round 3 → 30s
    private float timeRemaining;
    public int keysCollected = 0;
    public int keysRequired = 3;
    public bool gameEnded = false;
    private bool timerStarted = false;
    public Transform playerStartPosition;
    public GameObject player;
    public PlayerMovement playerMovement;
    public EndGameUI endGameUI;
    public GameObject winUI;
    public GameObject loseUI;
    public RoundCompleteUI roundCompleteUI;

    AudioSource audioSource;
    AudioSource roundCompleteAudioSource;
    AudioSource loseAudioSource;
    AudioSource winAudioSource;
    public AudioSource gameMusicSource;

    [Header("Managers")]
    public KeyManager keyManager;
    public ExitManager exitManager; // Optional: controls exit activation

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        StartRound();
        AudioSource[] sources = GetComponents<AudioSource>();
        if (sources.Length >= 3)
        {
            gameMusicSource = sources[0];
            gameMusicSource.Play();
            roundCompleteAudioSource = sources[1];
            loseAudioSource = sources[2];
            winAudioSource = sources[3];
            audioSource = sources[4];
        }
    }

    private IEnumerator PauseMusicWhilePlaying(AudioSource sfxSource)
    {
        if (gameMusicSource.isPlaying)
            gameMusicSource.Pause();

        sfxSource.Play();

        yield return new WaitForSeconds(sfxSource.clip.length);

        gameMusicSource.UnPause();
    }

    public AudioSource GetGameMusicSource()
    {
        return gameMusicSource;
    }

    void Update()
    {
        if (gameEnded || !timerStarted) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            LoseGame();
        }
    }

    public void StartRound()
    {
        Debug.Log($"Starting Round {currentRound}");

        ScoreManager.instance.ResetScore();

        timerStarted = false; // reset at start of each round

        if (currentRound - 1 < roundTimeLimits.Length)
            timeRemaining = roundTimeLimits[currentRound - 1];
        else
            timeRemaining = 30f;

        keysCollected = 0;
        keyManager.SpawnKeys();

        if (exitManager != null)
            exitManager.SetExitActive(false);

        // Re-enable movement when round starts
        if (playerMovement != null)
            playerMovement.SetMovementEnabled(true);
    }


    public void ResetTimer()
    {
        timerStarted = false;

        if (currentRound - 1 < roundTimeLimits.Length)
            timeRemaining = roundTimeLimits[currentRound - 1];
        else
            timeRemaining = 30f;

        //Debug.Log($"Timer reset for Round {currentRound}: {timeRemaining} seconds");
    }

    public void CollectKey()
    {
        keysCollected++; 
        ScoreManager.instance.AddPoint();
        Debug.Log($"Keys Collected: {keysCollected}/{keysRequired}");

        if (keysCollected >= keysRequired)
        {
            StartCoroutine(PlayAudioAfterDelay(0.5f));
            Debug.Log("All keys collected! Exit is now active.");
            if (exitManager != null)
                exitManager.SetExitActive(true);
        }
    }

    private IEnumerator PlayAudioAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }

    public void PlayerEscaped()
    {
        if (keysCollected < keysRequired) return;

        if (currentRound >= totalRounds)
        {
            // Final round completed → show win UI immediately
            gameEnded = true;
            Debug.Log("All rounds complete!");
            if (playerMovement != null)
                playerMovement.SetMovementEnabled(false);
            StartCoroutine(PauseMusicWhilePlaying(winAudioSource));
            winUI.SetActive(true); // Assuming you have this already
            return;
        }

        gameEnded = true;
        Debug.Log($"Round {currentRound} complete!");

        if (playerMovement != null)
            playerMovement.SetMovementEnabled(false);

        Time.timeScale = 0f;
        roundCompleteUI.Show(currentRound);
        StartCoroutine(PauseMusicWhilePlaying(roundCompleteAudioSource));
    }

    public void StartNextRound()
    {
        currentRound++;
        gameEnded = false;

        // Reset position
        if (player != null && playerStartPosition != null)
            player.transform.position = playerStartPosition.position;

        // Re-enable movement
        if (playerMovement != null)
            playerMovement.SetMovementEnabled(true);

        StartRound(); // re-spawn keys, reset timer
    }

    void LoseGame()
    {
        if (gameEnded) return;

        gameEnded = true;
        Debug.Log("Time ran out. You lose.");

        if (playerMovement != null)
            playerMovement.SetMovementEnabled(false);

        if (endGameUI != null)
            StartCoroutine(PauseMusicWhilePlaying(loseAudioSource));
            endGameUI.ShowLose();
    }

    public float GetTimeRemaining() => timeRemaining;
    public int GetCurrentRound() => currentRound;

    public void StartTimer()
    {
        if (timerStarted || gameEnded) return;

        timerStarted = true;
        Debug.Log($"Timer started for Round {currentRound}");
    }

    public bool HasTimerStarted()
    {
        return timerStarted;
    }

    public void TimerExpired()
    {
        if (!gameEnded)
        {
            LoseGame();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Just in case
        currentRound = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Just in case
        SceneManager.LoadScene(0); // Assumes main menu is at index 0
    }
}