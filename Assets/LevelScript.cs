using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour
{
    public bool ExitOnBackButton = false;
    public bool ReturnToMenuOnBackButton = false;

    public void LoadLevel(int level)
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(level);
    }

    void Update()
    {
        if (ExitOnBackButton && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
        else if (ReturnToMenuOnBackButton)
        {
            Application.LoadLevel(0);
        }
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
