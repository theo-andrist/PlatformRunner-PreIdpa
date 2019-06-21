using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0) && !PauseMenu.gameIsPaused)
        {
            gameObject.transform.position += transform.forward * 5;
            Destroy(this);
        }
    } 
}
