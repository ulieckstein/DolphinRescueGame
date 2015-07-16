using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiScript : MonoBehaviour
{

    public Text ScoreText;
    public int Score;
    public Text GameOverText;
    
    public Image OxyBar;
    
    private Color _oxyColorFull = new Color32(167, 202, 255, 255);
    private Color _oxyColorMedium = new Color32(172, 167, 255, 255);
    private Color _oxyColorLow = new Color32(209, 152, 212, 255);
    private Color _oxyColorCritical = new Color32(225, 89, 126, 255);
    
    void Start()
    {
        Score = 0;
        UpdateScore();
        GameOverText.enabled = false;
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

    public void UpdateOxygenLevel(float oxy)
    {
        OxyBar.fillAmount = oxy;
        ColorizeOxyBar(oxy);
        if (oxy < 0) GameOverText.enabled = true;
    }

    public void ColorizeOxyBar(float oxy)
    {
        var newColor = _oxyColorCritical;
        if (oxy > 0.15) newColor = _oxyColorLow;
        if (oxy > 0.4) newColor = _oxyColorMedium;
        if (oxy > 0.7) newColor = _oxyColorFull;
        OxyBar.color = newColor;
        //Debug.Log("Colorized Oxy Bar: " + newColor);
    }
}
