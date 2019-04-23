using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyPosition : MonoBehaviour
{
    public bool red;
    public bool blue;
    public bool yellow;

 /*  OnTriggerEnter(Collider other){
        if(other.transform.name == "Enemy Red"){
            red = true;
        }
        if(other.transform.name == "Enemy Blue"){
            blue = true;
        }
        if(other.transform.name == "Enemy Yellow"){
            yellow = true;
        }
        return red, blue, yellow;
    }
    OnTriggerExit(Collider other){
        if(other.transform.name == "Enemy Red"){
            red = false;
        }
        if(other.transform.name == "Enemy Blue"){
            blue = false;
        }
        if(other.transform.name == "Enemy Yellow"){
            yellow = false;
        }
        return red, blue, yellow;
    }*/
}
