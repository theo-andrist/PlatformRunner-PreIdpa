using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class giveEffect : MonoBehaviour
{
    public PowerUp[] powerUps;

    private GameObject[] enemys;

    private PowerUpManager pum;

    private void Awake()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        /*display = GameObject.Find("Canvas/DisplayPowerUp");
        displayText = display.GetComponent<Text>();*/

        pum = FindObjectOfType<PowerUpManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
            Pickup(other.gameObject);
        }
        
    }
    void Pickup(GameObject player){

        int rnd = Random.Range(0, 4 + 1);

        switch (rnd)
        {
            case 0:
                Teleport(player);
                break;
            case 1:
                SwitchPlace(player);
                break;
            case 3:
                StartCoroutine(LowGravity(player));
                break;
            case 4:
                StartCoroutine(Freeze(player));
                break;
        }

        //Destroy(gameObject);
        //spawnPowerUps.pwuInGame = false;
    }
    void Teleport(GameObject player)
    {
        StartCoroutine(pum.setDisplayText(powerUps[0].name + " (links-click)"));
        player.AddComponent<Teleport>();

        spawnPowerUps.pwuInGame = false;
        Destroy(gameObject);
    }
    void SwitchPlace(GameObject player)
    {
        StartCoroutine(pum.setDisplayText("switched"));

        int r = Random.Range(0, 3);

        Vector3 placeHolder = player.transform.position;
        player.transform.position = enemys[r].transform.position; 
        enemys[r].transform.position = placeHolder;

        spawnPowerUps.pwuInGame = false;
        Destroy(gameObject);
    }
    IEnumerator LowGravity(GameObject player)
    {
        StartCoroutine(pum.setDisplayText(powerUps[2].name + "!!!"));

        spawnPowerUps.powerActive = true;
        player.GetComponent<playerMovement>().gravityScale -= 100;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(powerUps[2].duration);

        player.GetComponent<playerMovement>().gravityScale += 100;
        spawnPowerUps.powerActive = false;

        spawnPowerUps.pwuInGame = false;
        Destroy(gameObject);
    }
    IEnumerator Freeze(GameObject player)
    {
        StartCoroutine(pum.setDisplayText(powerUps[3].name + "!"));

        spawnPowerUps.powerActive = true;
        player.GetComponent<Rigidbody>().isKinematic = true;

        Destroy(gameObject.transform.GetChild(0).gameObject);
        Destroy(gameObject.transform.GetChild(1).gameObject);
        Destroy(gameObject.transform.GetChild(2).gameObject);
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(powerUps[3].duration);

        player.GetComponent<Rigidbody>().isKinematic = false;
        spawnPowerUps.powerActive = false;

        spawnPowerUps.pwuInGame = false;
        Destroy(gameObject);
    }
}
