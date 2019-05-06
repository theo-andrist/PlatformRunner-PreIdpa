using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public CameraLook cl;
    public GameObject displayEnemy;

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
        displayEnemy.SetActive(true);
        Cursor.visible = false;
        cl.enabled = true;
        Time.timeScale = 1;
        gameIsPaused = false;
        Cursor.visible = false;
    }
    void Pause () {
        pauseMenuUI.SetActive(true);
        displayEnemy.SetActive(false);
        Cursor.visible = true;
        cl.enabled = false;
        Time.timeScale = 0;
        gameIsPaused = true;
        Cursor.visible = true;
    }
}
