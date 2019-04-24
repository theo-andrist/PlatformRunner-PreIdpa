using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEntities : MonoBehaviour
{
    public GameManager gameManager;
    void OnTriggerStay(Collider other){
        gameManager = FindObjectOfType<GameManager>();
        
        if(other.transform.name == "Player"){
            Destroy(other.gameObject);
            gameManager.Lose();
        }
        if (other.transform.name == "Enemy") {
            Destroy(other.gameObject);
            if (OnDestroyEnemys.killcount == 3) {
                gameManager.Win();
            }
        }
    }
}
