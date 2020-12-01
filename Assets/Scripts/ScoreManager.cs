using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    int score;

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void Awake()
    {
        if(instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        UpdateScore();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    public int GetCurrentScore()
    {
        return score;
    }
}
