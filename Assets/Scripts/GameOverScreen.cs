using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text scoreText;

    public void Setup(int score) {
        gameObject.SetActive(true);

        scoreText.text = "SCORE: " + score.ToString();

    }
}
