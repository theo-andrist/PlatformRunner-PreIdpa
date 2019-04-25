using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEntities : MonoBehaviour
{
    public GameManager gameManager;
    public playerMovement pM;
    public CameraLook cL;
    public GameObject player;
    private Rigidbody rb;
    private bool gameHasEnded = false;
    private int killcount = 0;
    void Awake () {
        gameManager = FindObjectOfType<GameManager>();
        pM = FindObjectOfType<playerMovement>();
        cL = FindObjectOfType<CameraLook>();
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
    }
    void OnTriggerEnter(Collider other){
        
        if(other.transform.name == "Player" && !gameHasEnded){
            
            gameManager.Lose();
        }
        if (other.transform.tag == "Enemy" && !gameHasEnded) {
            Destroy(other.gameObject);
            killcount++;
           if (killcount == 3) {
             gameManager.Win();
            }
        }
    }
}
