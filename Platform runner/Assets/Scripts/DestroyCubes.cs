using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCubes : MonoBehaviour
{     
    void OnCollisionExit(Collision other)
    {
        if(other.transform.tag == "Cube")
        {
            Destroy(other.gameObject);
        }
    }
}
