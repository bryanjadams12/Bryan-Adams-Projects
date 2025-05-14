using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; 

    public TextMeshProUGUI scoreText;
    int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        scoreText.text = score.ToString() + " KEYS";
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " KEYS";
    }
    public void ResetScore()
{
    score = 0;
    scoreText.text = score.ToString() + " KEYS";
}
}
