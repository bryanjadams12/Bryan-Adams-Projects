using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    private int score = 0;
    private int maxKeys = 3;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        UpdateScoreText();
    }

    public void AddPoint()
    {
        score += 1;
        UpdateScoreText();
    }

    public void ResetScore()
    {
        Debug.Log("ResetScore() called");
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score + "/" + maxKeys + " KEYS";
    }
}
