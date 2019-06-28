using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPowerUps : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;

    public float powerUpSpawnTime { get; }

    public Vector2 maxXAndZ;
      
    void Awake()
    {
        //macht no nüt
        int Layers = PlayerPrefs.GetInt("DropDownValue") +1;

        
        StartCoroutine(InstantiatePU());
    }
    public IEnumerator InstantiatePU(){
        yield return new WaitForSeconds(powerUpSpawnTime);
        Debug.Log("PowerUp spawned");
        GameObject pU = Instantiate(prefab, randomPosition(1, maxXAndZ), prefab.transform.rotation, parent);        
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
