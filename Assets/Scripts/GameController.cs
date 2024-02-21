using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float gameTime = 30.0f; // Total game time in seconds

    void Start() {}

    // Acts as timer for game 
    void Update()
    {
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
        {
            // End the game
            Debug.Log("Game Over!");
        }
    }
}

