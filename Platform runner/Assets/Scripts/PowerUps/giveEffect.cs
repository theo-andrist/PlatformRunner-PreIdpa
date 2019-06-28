using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class giveEffect : MonoBehaviour
{
    public PowerUp[] powerUps;

    private GameObject[] enemys;

    private PowerUpManager pum;

    private spawnPowerUps spwu;

    public ParticleSystem blueFire;

    private void Awake()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        /*display = GameObject.Find("Canvas/DisplayPowerUp");
        displayText = display.GetComponent<Text>();*/

        pum = FindObjectOfType<PowerUpManager>();

        spwu = FindObjectOfType<spawnPowerUps>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
            Debug.Log("Picked up");
            Pickup(other.gameObject);
        }
        
    }
    void Pickup(GameObject player){

        int rnd = Random.Range(0, 3 + 1);
        Debug.Log("Pickup() called: rnd = " + rnd);

        switch (rnd)
        {
            case 0:
                StartCoroutine(Teleport(player));
                break;
            case 1:
                StartCoroutine(SwitchPlace(player));
                break;
            case 2:
                StartCoroutine(LowGravity(player));
                break;
            case 3:
                StartCoroutine(Freeze(player));
                break;
        }
        Debug.Log("Pickup() ended");
    }
        //needs to wait or pum.setdisplaytext wont reset the display 

    IEnumerator Teleport(GameObject player)
    {
        Instantiate(blueFire, transform.position, transform.rotation);
        disable();

        player.AddComponent<Teleport>();

        StartCoroutine(pum.setDisplayText(powerUps[0].name + " (links-click)", powerUps[0].displayDuration));
        yield return new WaitForSeconds(powerUps[0].displayDuration);

        StartCoroutine(AfterEffectGiven());
    }
    //needs to wait or pum.setdisplaytext wont reset the display 
    IEnumerator SwitchPlace(GameObject player)
    {       
        Instantiate(blueFire, transform.position, transform.rotation);
        disable();

        int r = Random.Range(0, 3);

        Vector3 placeHolder = player.transform.position;
        player.transform.position = enemys[r].transform.position; 
        enemys[r].transform.position = placeHolder;
        
        StartCoroutine(pum.setDisplayText("switched", powerUps[1].displayDuration));
        yield return new WaitForSeconds(powerUps[1].displayDuration);

        StartCoroutine(AfterEffectGiven());
    }
    IEnumerator LowGravity(GameObject player)
    {
        Instantiate(blueFire, transform.position, transform.rotation);
        disable();

        player.GetComponent<playerMovement>().gravityScale -= 100;

        Destroy(gameObject.transform.GetChild(0).gameObject);
        Destroy(gameObject.transform.GetChild(1).gameObject);
        Destroy(gameObject.transform.GetChild(2).gameObject);
        GetComponent<Collider>().enabled = false;

        StartCoroutine(pum.setDisplayText(powerUps[2].name + "!!!", powerUps[2].displayDuration));
        yield return new WaitForSeconds(powerUps[2].duration);

        player.GetComponent<playerMovement>().gravityScale += 100;

        StartCoroutine(AfterEffectGiven());        
    }

    IEnumerator Freeze(GameObject player)
    {
        Instantiate(blueFire, transform.position, transform.rotation);
        disable();

        StartCoroutine(pum.setDisplayText(powerUps[3].name + "!", powerUps[3].displayDuration));
        player.GetComponent<Rigidbody>().isKinematic = true;

        yield return new WaitForSeconds(powerUps[3].duration);

        player.GetComponent<Rigidbody>().isKinematic = false;

        StartCoroutine(AfterEffectGiven());
    }
    
    private void disable(){

        Destroy(gameObject.transform.GetChild(0).gameObject);
        Destroy(gameObject.transform.GetChild(1).gameObject);
        Destroy(gameObject.transform.GetChild(2).gameObject);
        GetComponent<Collider>().enabled = false;
    }

    IEnumerator AfterEffectGiven(){

        //needs to wait or pum.setdisplaytext wont instatiate the pwup 
        StartCoroutine(spwu.InstantiatePU());
        yield return new WaitForSeconds(spwu.powerUpSpawnTime);

        Destroy(gameObject);
    }    
}
