using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    int score;
    public Text scoreDisplay;

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
        }
    }
}
