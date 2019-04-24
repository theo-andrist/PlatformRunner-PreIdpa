using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEntities : MonoBehaviour
{
    public GameManager gameManager;
    void OnTriggerStay(Collider other){
        if(other.transform.tag == "bot" || other.transform.name == "Player"){
            //Destroy(other.gameObject);
            gameManager = FindObjectOfType<GameManager>();
            gameManager.EndGame();
        }
    }
}
