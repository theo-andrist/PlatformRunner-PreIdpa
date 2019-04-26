using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //bool gameHasEnded = false;
    public CameraLook cl;
    public bool gameFinish = false;
    public GameObject loseUI;
    public GameObject winUI;

    /*public void EndGame () {

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GameOver"); 
        }
        
    }*/

    public void Win () {
        if(!gameFinish){
            gameFinish = true;
            winUI.SetActive(true);
            pauseGame();
        }
        
    }

    public void Lose () {
        if(!gameFinish){
        gameFinish = true;
        pauseGame();
        //rb.velocity = new Vector3(0,0,0);
        loseUI.SetActive(true);
        } 
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
    }

    void pauseGame () {
        cl.enabled = false;
        Time.timeScale = 0;
        /*gameHasEnded = true;
        pM.enabled = false;
        
        rb.useGravity = false;*/
    }
}
