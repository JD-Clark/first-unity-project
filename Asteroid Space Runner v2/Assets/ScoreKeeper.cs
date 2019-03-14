using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    int score;
    public Text scoreDisplay;
    public Text highScore;

    void Start()
    {
        highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("hScore", 0).ToString();
    }

    private void Update()
    {
        scoreDisplay.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            score++;
            Debug.Log(score);
            if (score > PlayerPrefs.GetInt("hScore", 0))
            {
                PlayerPrefs.SetInt("hScore", score);
                highScore.text = "HIGH SCORE: " + score.ToString();
            }
        }

    }
}
