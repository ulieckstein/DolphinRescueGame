using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {

    public void LoadLevel(int level)
    {
        Application.LoadLevel(level);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }

        if (Input.GetKeyDown(KeyCode.Menu))
        {
            LoadLevel(2);
        }
    }
}
