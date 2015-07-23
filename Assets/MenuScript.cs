using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text ScoreText ;

    void Start ()
    {
        var score = PlayerPrefs.GetInt("highscore", 0);
        if (score > 0) ScoreText.text = String.Format("Highscore: {0}", score);
    }
}
