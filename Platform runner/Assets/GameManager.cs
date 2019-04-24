using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    bool gameLose = false;
    bool gameWon = false;
    public void EndGame () {

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
           Debug.Log("GameOver"); 
        }
        
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
