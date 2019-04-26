using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject itemBox;   
    private Rigidbody rb;
    public GameObject player;
    public playerMovement pM;//ist kleingeschriben worden!!!
    public EnemyMovement eM;
    int randomOrtX;
    int randomOrtZ;
    int randomItem;
    int[] Items = new int[2];
    //int Items;
    //int ItemsAnzahl;
    bool aktivWennBenötigt = false;
    public float ItemTimer = 8;
    private float ItemCountdown;
    public float ItemDuration = 4;
    private float ItemDurationCountdown;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");
        pM = FindObjectOfType<playerMovement>();
        eM = FindObjectOfType<EnemyMovement>();
        rb = player.GetComponent<Rigidbody>();
        RandomPosition();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (ItemCountdown > 0) {
            ItemCountdown -= Time.deltaTime;
        }
        if (ItemCountdown <= 0 ){

            //RandomPosition();
            ItemCountdown = ItemTimer;
        }
        if (ItemDurationCountdown > 0) {
            Debug.Log("Item Countdown");
            ItemDurationCountdown -= Time.deltaTime;
        }
        if (ItemDurationCountdown <= 0 && aktivWennBenötigt == true){
            Debug.Log("Off");
            Reset();
        }
    }
    void OnTriggerEnter(Collider other){
        aktivWennBenötigt = true;
        RandomPosition();
        RandomItemContent();
        ItemDurationCountdown = 0;

        switch (randomItem)
        {
            case 0:
              Debug.Log("Star");
              pM.gravityScale = 0;
              rb.drag = 1.5f;
              //pM.enabled = false;
              break;
          case 1:
              Debug.Log("Freeze");
              eM.enabled = false;
              break;
          case 2:

              break;
          default:
                Debug.Log("Default");
              break;
        }
        ItemDurationCountdown = ItemDuration;
    }
    void RandomPosition(){
        randomOrtX = Random.Range(0, 30);
        randomOrtZ = Random.Range(0, 30);
        itemBox.transform.position = new Vector3(randomOrtX, 1.5f, randomOrtZ);
        
    }
    void RandomItemContent(){
        randomItem = Random.Range(0, Items.Length);
    }
    void Reset() {
        //Player Rigidbody
        rb.useGravity = true;
        rb.drag = 2f;

        //PlayerMovement
        pM.enabled = true;
        pM.gravityScale = 200;

        //EnemyMovement
        //eM.enabled = true;
    }

}
