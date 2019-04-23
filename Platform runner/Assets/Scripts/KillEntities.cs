using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEntities : MonoBehaviour
{
    void OnTriggerStay(Collision other){
        if(other.transform.tag == "bot" || other.transform.name == "Player"){
            Destroy(other.transform.gameObject);
        }
    }
}
