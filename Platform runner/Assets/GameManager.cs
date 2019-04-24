using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public bool gameFinish = false;
    public GameObject loseUI;
    public GameObject winUI;
    public void EndGame () {

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
           Debug.Log("GameOver"); 
        }
        
    }
    public void Win () {
        gameFinish = true;
        winUI.SetActive(true);
        
    }
    public void Lose () {
        gameFinish = true;
        loseUI.SetActive(true);
        
    }
   
    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
    }
}
