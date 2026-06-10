using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public PlayerStat playerStat;
    public TextMeshProUGUI scoreText;
    public static int finalScore;

    // Start is called before the first frame update
    void Start()
    {
        // Jika null, berarti ada di Game Over scene
        if (playerStat == null)
        {
            scoreText.text = "Total Score: " + finalScore;
            return;
        }
        UpdateScore(playerStat.GetScore());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStat == null) return;

        int currentScore = playerStat.GetScore();
        UpdateScore(currentScore);
        finalScore = currentScore;
    }
    void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}