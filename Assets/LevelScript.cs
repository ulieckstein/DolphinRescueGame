﻿using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour
{
    public bool ExitOnBackButton = false;
    public bool ReturnToMenuOnBackButton = false;

    public void LoadLevel(int level)
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(level);

        #if !UNITY_ANDROID
            GameObject.FindGameObjectWithTag("AndroidOnly").SetActive(false);
        #endif
    }

    void Update()
    {
        if (ExitOnBackButton && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
        else if (ReturnToMenuOnBackButton && Input.GetKeyDown(KeyCode.Escape))
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
