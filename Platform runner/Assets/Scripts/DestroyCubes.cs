using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCubes : MonoBehaviour
{     
    public playerMovement pm;
    float groundRaycastRange;
    RaycastHit lastHit;
    RaycastHit hit;
    bool lastHitInitializated = false;
    void Start(){
        groundRaycastRange = pm.RaycastRange + 0.1f;
    }
    void Update(){

        if(pm.IsGrounded()){
            
            if (Physics.Raycast(transform.position, Vector3.down, out hit, groundRaycastRange) && hit.collider.tag == "Cube" && !lastHitInitializated)
            {
                lastHit = hit;
                lastHitInitializated = true;
            }
            if (lastHit.transform.gameObject != hit.transform.gameObject)
            {
                Debug.Log("destroy " + lastHit.transform.name);
                Destroy(lastHit.transform.gameObject);
                lastHitInitializated = false;
            }
        }        
    }
}
