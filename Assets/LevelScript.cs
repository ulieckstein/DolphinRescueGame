using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour
{
    public bool ExitOnBackButton = false;

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
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
