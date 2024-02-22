using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;

    public TMP_Text scoreText;
    public static int currentScore = 0;

    void Update() 
    {
        if (GameController.isGameOver) return;
    }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "SCORE: " + currentScore.ToString();
    }

    public void IncreaseScore()
    {
        if (GameController.isGameOver) return;
        currentScore++;
        scoreText.text = "SCORE: " + currentScore.ToString();
    }
}
