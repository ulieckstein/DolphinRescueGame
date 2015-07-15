using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public Text ScoreText;
    public int Score;

    void Start()
    {
        Score = 0;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = string.Format("{0:000}", Score);
    }

    public void AddScore(int newScore)
    {
        Score += newScore;
        Debug.Log("new score is " + Score);
        UpdateScore();
    }

    public void SubtractScore(int newScore)
    {
        Score -= newScore;
        if (Score < 0) Score = 0;
        Debug.Log("new score is " + Score);
        UpdateScore();
    }
}
