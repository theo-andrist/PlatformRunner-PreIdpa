using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public CameraLook cl;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            } else 
            {
                Pause();
            }
        }
    }
    public void Resume () {
        pauseMenuUI.SetActive(false);
        cl.enabled = true;
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    void Pause () {
        pauseMenuUI.SetActive(true);
        cl.enabled = false;
        Time.timeScale = 0;
        gameIsPaused = true;
    }
}
