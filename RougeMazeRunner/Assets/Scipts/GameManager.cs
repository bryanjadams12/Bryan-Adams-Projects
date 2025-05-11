using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    void Update()
    {
        if (gameEnded || !timerStarted) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            LoseGame();
        }
    }

    void StartRound()
    {
        Debug.Log($"Starting Round {currentRound}");

        timerStarted = false; // reset at start of each round

        if (currentRound - 1 < roundTimeLimits.Length)
            timeRemaining = roundTimeLimits[currentRound - 1];
        else
            timeRemaining = 30f;

        keysCollected = 0;

        keyManager.SpawnKeys();

        if (exitManager != null)
            exitManager.SetExitActive(false);
    }

    public void CollectKey()
    {
        keysCollected++;

        if (keysCollected >= keysRequired)
        {
            Debug.Log("All keys collected! Find the exit!");

            if (exitManager != null)
                exitManager.SetExitActive(true);
        }
    }

    public void PlayerEscaped()
    {
        if (keysCollected < keysRequired) return;

        if (currentRound >= totalRounds)
        {
            WinGame();
        }
        else
        {
            currentRound++;
            StartRound();
        }
    }

    void WinGame()
    {
        gameEnded = true;
        Debug.Log("You completed all rounds! You win!");
        // SceneManager.LoadScene("WinScene");
    }

    void LoseGame()
    {
        gameEnded = true;
        Debug.Log("Time ran out. You lose.");
        // SceneManager.LoadScene("LoseScene");
    }

    public float GetTimeRemaining() => timeRemaining;
    public int GetCurrentRound() => currentRound;

    public void StartTimer()
    {
        timerStarted = true;
        Debug.Log("Timer started!");
    }

    public bool HasTimerStarted()
    {
        return timerStarted;
    }
}