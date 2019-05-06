using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
	public float speed = 3;

    private void Awake()
    {
        Cursor.visible = false;
    }

    void Update () {
		float h = speed * Input.GetAxis("Mouse X");

        transform.Rotate(0, h, 0);

        if (GameManager.gameFinish)
        {
            Cursor.visible = true;
        }
    }
}
