using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class SelectOnInput : MonoBehaviour {

    public EventSystem eventsystem;
    public GameObject selectedObject;

    private bool buttonSelected;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
        {
            eventsystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
	}
    private void OnDisable()
    {
        buttonSelected = false;
    }
}
