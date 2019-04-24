using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public bool gameFinish = false;
    public GameObject LoseUI;
    public GameObject WinUI;
    public void EndGame () {

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
           Debug.Log("GameOver"); 
        }
        
    }
    public void Win () {
        gameFinish = true;
        WinUI.SetActive(true);
        
    }
    public void Lose () {
        gameFinish = true;
        LoseUI.SetActive(true);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
