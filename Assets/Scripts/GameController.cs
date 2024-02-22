using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool isGameOver = false;
    public float gameTime = 30.0f; // Total game time in seconds
    public GameOverScreen GameOverScreen;

    // Acts as timer for game 
    void Update()
    {
        if (!isGameOver)
        {
            gameTime -= Time.deltaTime;
            if (gameTime <= 0)
            {
                isGameOver = true;
                GameOverScreen.Setup(ScoreCounter.currentScore);
            }
        }
        
    }
}