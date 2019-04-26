using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void setTimeScale(float setTimeScale)
    {
        Time.timeScale = setTimeScale;
    }
    public void PlaySound(string name)
    {
        FindObjectOfType<audioManager>().Play(name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
