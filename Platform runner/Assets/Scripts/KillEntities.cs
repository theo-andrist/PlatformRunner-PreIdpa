using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEntities : MonoBehaviour
{
    public GameManager gameManager;
    int enemyCounter = 0;
    void OnTriggerStay(Collider other){
        gameManager = FindObjectOfType<GameManager>();
        
        if(other.transform.name == "Player"){
            Destroy(other.gameObject);
            gameManager.Lose();
        }
        if (other.transform.name == "Enemy") {
            Destroy(other.gameObject);
            enemyCounter++;
            if (enemyCounter == 3) {
                gameManager.Win();
            }
        }
    }
}
