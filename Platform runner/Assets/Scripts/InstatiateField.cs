using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateField : MonoBehaviour
{

    public GameObject Prefab;
    private int Layers;
    public int Size = 21;
    public Transform Parent;

    private void Awake()
    {
        Layers = PlayerPrefs.GetInt("DropDownValue") +1;

        Vector3 position = new Vector3(0, 0, 0);

        for (int y = 0; y < Layers; y++)
        {
            for (int z = 0; z < Size; z++)
            {
                for (int x = 0; x < Size; x++)
                {
                    GameObject p = Instantiate(Prefab, position, Quaternion.Euler(new Vector3(0, 0, 0)), Parent);
                    p.name = "Platform x: " + x +" y: " + y +" z: " + z ;
                    position += new Vector3(1.5f, 0, 0);
                }
                position = new Vector3(0, position.y, position.z);
                position += new Vector3(0, 0, 1.5f);
            }
            position = new Vector3(0, position.y, 0);
            position += new Vector3(0, -10, 0);
        }
    }
}
