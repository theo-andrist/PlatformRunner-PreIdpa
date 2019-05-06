using UnityEngine;
using UnityEngine.UI;

public class giveEffect : MonoBehaviour
{
    public GameObject player;

    public GameObject[] enemys;

    public GameObject display;
    public Text displayText;

    public PowerUpManager pum;

    private void Awake()
    {
        player = GameObject.Find("Player");

        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        display = GameObject.Find("Canvas/DisplayPowerUp");
        displayText = display.GetComponent<Text>();

        pum = FindObjectOfType<PowerUpManager>();
        pum.displaytext = displayText;
    }
    private void OnTriggerEnter(Collider other)
    {
        int rnd = Random.Range(0, 4 + 1);
        switch (rnd)
        {
            case 0:
                Teleport();
                break;
            case 1:
                SwitchPlace();
                break;
            case 2:
                LowGravity();
                break;
            case 3:
                LowGravity();
                break;
            case 4:
                LowGravity();
                break;
        }
        Destroy(gameObject);
    }
    void Teleport()
    {
        player.AddComponent<Teleport>();
        displayText.text = "Teleport (left-click)";
        pum._resetDisplay = true;
        
    }
    void SwitchPlace()
    {
        displayText.text = "Switched";
        pum._resetDisplay = true;
    }
    void LowGravity()
    {
        displayText.text = "Low Gravity!!!";
        pum._resetDisplay = true;
    }
    void Freeze()
    {
        displayText.text = "Freeze!";
        pum._resetDisplay = true;
    }
    
}
