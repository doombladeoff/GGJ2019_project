using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public static bool GamePaused = false;
    public GameObject PauseUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }
    public void Resume()
    {
        GamePaused = false;
        Time.timeScale = 1f;
        PauseUI.SetActive(false);
    }
    public void Paused()
    {
        GamePaused = true;
        Time.timeScale = 0f;
        PauseUI.SetActive(true);
    }
}
