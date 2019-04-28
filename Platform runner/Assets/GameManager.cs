using UnityEngine;

public class GameManager : MonoBehaviour
{
    //bool gameHasEnded = false;
    public CameraLook cl;
    public bool gameFinish = false;
    public GameObject loseUI;
    public GameObject winUI;

    public GameObject displayEnemy;
    private void OnEnable()
    {
        Cursor.visible = false;
    }

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
            loseUI.SetActive(true);
        } 
    }

    void pauseGame () {
        Cursor.visible = true;
        Destroy(displayEnemy);
        cl.enabled = false;
        Time.timeScale = 0;
    }
}
