using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setDeathZone : MonoBehaviour
{
    public GameObject Prefab;
    public Transform Parent;
    public int Size = 20;
    void Awake ()
    {
        Vector3 position = new Vector3(0, 0, 0);

        for (int z = 0; z < Size; z++)
        {
            for (int x = 0; x < Size; x++)
            {
                GameObject p = Instantiate(Prefab, position, Quaternion.Euler(new Vector3(0, 0, 0)), Parent);
                p.name = "DeathCube x: " + x +" y: 4 z: " + z ;
                position += new Vector3(1.5f, 0, 0);
            }
            position = new Vector3(0, position.y, position.z);
            position += new Vector3(0, 0, 1.5f);
        }
    }
}
