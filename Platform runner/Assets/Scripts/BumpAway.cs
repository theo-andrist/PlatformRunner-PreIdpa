using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpAway : MonoBehaviour
{
    public float height = 15;
    public float distance = 20;
    private Rigidbody rb;

    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Enemy" || other.gameObject.name == "Player" ){
            rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(0, height, 0, ForceMode.Impulse);
            rb.AddForce(transform.forward * distance, ForceMode.Impulse);
        }
    }
}
