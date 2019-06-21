using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPowerUps : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;

    public float powerUpSpawnTime;

    public Vector2 maxXAndZ;

    //werden in GiveEffects verändert (powerActive, pwuInGame)
    public static bool powerActive = false;
    private bool timerRunning;
    public static bool pwuInGame = false;

    void Update()
    {
        if(!powerActive && !timerRunning && !pwuInGame){
            InvokeRepeating("InstantiatePU",powerUpSpawnTime, 10f);
            timerRunning = true;
        }
    }

    private void CountDownForPUSpawn(float time){

        if (time > 0)
        {
            time -= Time.deltaTime;
            CountDownForPUSpawn(powerUpSpawnTime);
        }
        else{

            InstantiatePU();
        }
    }
    public void InstantiatePU(){

        GameObject pU = Instantiate(prefab, randomPosition(1, maxXAndZ), prefab.transform.rotation, parent);
        pwuInGame = true;
        powerActive = true;
        timerRunning = false;
        
    }

    Vector3 randomPosition(int layer, Vector2 _maxXAndZ)
    {
        float xP = Random.Range(0,_maxXAndZ[0]);
        float yP = 0;
        float zP = Random.Range(0, _maxXAndZ[0]);

        int jumpOrNot = Random.Range(0, 2);

        switch (layer)
        {
             case 1:
                if (jumpOrNot == 0)
                {
                    yP = 1;
                }
                else
                {
                    yP = 2.5f;
                }
             break;
             case 2:
                if (jumpOrNot == 0)
                {
                    yP = -9;
                }
                else
                {
                    yP = -7.5f;
                }
             break;
             case 3:
                if (jumpOrNot == 0)
                {
                    yP = -19;
                }
                else
                {
                    yP = -17.5f;
                }
              break;
        }
        return new Vector3(xP, yP, zP);
    }
}
