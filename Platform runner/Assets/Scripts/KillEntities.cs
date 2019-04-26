using UnityEngine.UI;
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

    public Text Yellow;
    public Text Blue;
    public Text Red;
    void Awake () {
        gameManager = FindObjectOfType<GameManager>();
        pM = FindObjectOfType<playerMovement>();
        cL = FindObjectOfType<CameraLook>();
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
    }
    void OnTriggerEnter(Collider other){
        
        if(other.transform.name == "Player" && !gameHasEnded){
            FindObjectOfType<audioManager>().Play("Die");
            gameManager.Lose();
        }
        if (other.transform.tag == "Enemy" && !gameHasEnded) {

            FindObjectOfType<audioManager>().Play("EnemyDie");
            
            switch (other.transform.name)
            {
                case "Enemy Red":
                Destroy(Red);
                break;
                case "Enemy Blue":
                Destroy(Blue);
                break;
                case "Enemy Yellow":
                Destroy(Yellow);
                break;
            }
            Destroy(other.gameObject);
            killcount++;
           if (killcount == 3) {
             gameManager.Win();
            }
        }
    }
}
